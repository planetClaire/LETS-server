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

namespace GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<GraphQLDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));
            services
                .AddGraphQLServer()
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
