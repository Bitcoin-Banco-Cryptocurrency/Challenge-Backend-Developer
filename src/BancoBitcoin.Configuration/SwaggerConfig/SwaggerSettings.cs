using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Text;

namespace BancoBitcoin.Configuration.SwaggerConfig
{
    public static class SwaggerSettings
    {
        public static IServiceCollection AddConfigurationSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var sb = new StringBuilder();
                sb.AppendLine("Api para teste do Grupo Banco Bitcoin.");
                sb.AppendLine("Aplicação desenvolvida na plataforna .Net utilizando ASP.NET Core e atualmente hospedadada em docker container.");

                c.SwaggerDoc("v1",
                            new Info
                            {
                                Title = "Grupo Banco Bitcoin Swagger",
                                Version = "v1",
                                Description = sb.ToString()
                            });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "BancoBitcoin.Api.xml");
                c.IncludeXmlComments(filePath);
            });

            return services;
        }

        public static IApplicationBuilder AddConfigurationSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "v1/swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/v1/swagger/v1/swagger.json", "Grupo Banco Bitcoin Swagger V1");
            });

            return app;
        }
    }
}
