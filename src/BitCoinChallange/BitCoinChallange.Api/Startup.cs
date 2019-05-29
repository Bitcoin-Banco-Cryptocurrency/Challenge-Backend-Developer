using BitCoinChallange.Infra.CrossCutting.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using BitCoinChallange.Api.ApiConfigurations;
using MediatR;

namespace BitCoinChallange.Api
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

			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "BitCoinChallange App",
					Description = "BitCoinChallange API Documentation",
					Contact = new Contact { Name = "Jefferson Moraes", Email = "JEFFERSON.MORAEAS26@GAIL.COM", Url = "https://github.com/Jeffsmoraes/Challenge-Backend-Developer/tree/development" }
				});
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var xmlPath = Path.Combine(basePath, "BitCoinChallange.Api.xml");
				s.IncludeXmlComments(xmlPath);
			});
			services.AddMvc().AddJsonOptions(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
			services.AddMediatR(typeof(Startup));
			services.AddAutoMapperSetup();
			RegisterServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSwagger();
			app.UseSwaggerUI(s =>
			{
				s.SwaggerEndpoint("/swagger/v1/swagger.json", "BitCoinChallange Project API v1.1");
			});

			app.UseHttpsRedirection();
			app.UseMvc();
		}

		private static void RegisterServices(IServiceCollection services)
		{
			InjectNative.RegisterServices(services);
		}
	}
}
