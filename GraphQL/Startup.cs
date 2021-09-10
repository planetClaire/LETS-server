
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using GraphQL.DataLoader;
using GraphQL.Localities;
using GraphQL.Members;
using GraphQL.Notices;
using GraphQL.Types;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string LETSCorsPolicy = "LETSCorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            FirebaseApp.Create();

            services.AddAuthorization();

            var allowedOrigins = Configuration.GetValue<string>("AllowedOrigins");
            if (!string.IsNullOrEmpty(allowedOrigins))
            {
                var origins = allowedOrigins.Split(";");
                services.AddCors(options =>
                {
                    options.AddPolicy(name: LETSCorsPolicy,
                        builder =>
                        {
                            builder.WithOrigins(origins)
                                .AllowAnyHeader()
                                .AllowCredentials().AllowAnyMethod();
                        });
                });
            }

            services.AddPooledDbContextFactory<GraphQLDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));
            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddType(new UuidType('D'))
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<LocalityQueries>()
                    .AddTypeExtension<MemberQueries>()
                    .AddTypeExtension<NoticeQueries>()
                //.AddTypeExtension<NoticeTypeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<LocalityMutations>()
                    .AddTypeExtension<MemberMutations>()
                    .AddTypeExtension<NoticeMutations>()
                //.AddTypeExtension<NoticeTypeMutations>()
                .AddType<LocalityType>()
                .AddType<MemberType>()
                .AddType<NoticeType>()
                //.AddType<NoticeTypeType>()
                //.EnableRelaySupport()
                .AddGlobalObjectIdentification()
                .AddQueryFieldToMutationPayloads()
                .AddDataLoader<LocalityByIdDataLoader>()
                .AddDataLoader<NoticeByIdDataLoader>()
                .AddDataLoader<MemberByIdDataLoader>()
            //.AddDataLoader<NoticeTypeByIdDataLoader>()
            ;

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    var fbAppId = Configuration.GetValue<string>("FIREBASE_APPLICATION_ID");
                    options.Authority = "https://securetoken.google.com/" + fbAppId;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/" + fbAppId,
                        ValidateAudience = true,
                        ValidAudience = fbAppId,
                        ValidateLifetime = true
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = ctx =>
                        {
                            var adminClaim = ctx.Principal.Claims.FirstOrDefault(c => c.Type == "admin");
                            if (adminClaim != null && bool.Parse(adminClaim.Value))
                            {
                                if (ctx.Principal.Identity is ClaimsIdentity identity)
                                {
                                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                                }
                            }
                            return Task.CompletedTask;
                        }
                    };

                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(LETSCorsPolicy);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            CreateAdminUser().GetAwaiter().GetResult();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });


        }

        private async Task CreateAdminUser()
        {
            var adminEmail = Configuration.GetValue<string>("AdminUser");
            if (!string.IsNullOrEmpty(adminEmail))
            {
                UserRecord userRecord = null;
                try
                {
                    userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(adminEmail);
                }
                catch (FirebaseAuthException ex)
                {
                    if (ex.AuthErrorCode == AuthErrorCode.UserNotFound)
                    {
                        UserRecordArgs args = new UserRecordArgs()
                        {
                            Email = adminEmail,
                            EmailVerified = true,
                            Disabled = false,
                        };
                        userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);

                    }
                }
                var claims = new Dictionary<string, object>()
                {
                    { "admin", true },
                };
                await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userRecord.Uid, claims);
            }

        }
    }
}
