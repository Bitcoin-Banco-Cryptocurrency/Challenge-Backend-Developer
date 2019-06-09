using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using bitcoin_project.Service;
using bitcoin_project.Data;

namespace bitcoin_project
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
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookData, BookData>();

            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder =>
                        {
                            builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        });
                });

            
            SetupSwagger(services);
        }

        private static void SetupSwagger(IServiceCollection services)
        {
            //services.ConfigureSwaggerGen(x =>
            //{
            //    x.IncludeXmlComments($"{AppContext.BaseDirectory}BitcoinProject.Api.xml");
            //});

            

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.CustomSchemaIds(x => x.FullName);
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Bitcoin Project for Backend Dev Position",
                    Version = "v1",
                    Description = "Same as title...",
                    TermsOfService = "Terms of Service"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
              .UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("v1/swagger.json", "API V1");
              });

            
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
