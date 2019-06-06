using BooksApi.Api.Models;
using BooksApi.Infra.Repositories;
using BooksApi.Models.Books;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<BookApiSchema>();

            services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);

            services.AddScoped<IBookRepository, BookRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphQL<BookApiSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { Path = "/api", GraphQLEndPoint = "/graphql" });
            app.UseMvc(routes =>
                routes.MapRoute(
                name: "default",
                template: "api"
            ));
        }
    }
}
