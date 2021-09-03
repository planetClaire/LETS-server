using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.DataLoader;
using GraphQL.Localities;
using GraphQL.Members;
using GraphQL.MemberTypes;
using GraphQL.Notices;
using GraphQL.Types;
using System;
using Microsoft.IdentityModel.Tokens;
using FirebaseAdmin;

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
                    .AddTypeExtension<MemberTypeQueries>()
                    .AddTypeExtension<NoticeQueries>()
                //.AddTypeExtension<NoticeTypeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<LocalityMutations>()
                    .AddTypeExtension<MemberMutations>()
                    .AddTypeExtension<MemberTypeMutations>()
                    .AddTypeExtension<NoticeMutations>()
                //.AddTypeExtension<NoticeTypeMutations>()
                .AddType<LocalityType>()
                .AddType<MemberType>()
                .AddType<MemberTypeType>()
                .AddType<NoticeType>()
                //.AddType<NoticeTypeType>()
                .EnableRelaySupport()
                .AddDataLoader<LocalityByIdDataLoader>()
                .AddDataLoader<NoticeByIdDataLoader>()
                .AddDataLoader<MemberByIdDataLoader>()
                .AddDataLoader<MemberTypeByIdDataLoader>()
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL()
                // block any unauthorised access
                .RequireAuthorization();
            });


        }
    }
}
