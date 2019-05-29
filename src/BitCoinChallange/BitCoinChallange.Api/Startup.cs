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
using System;

namespace BitCoinChallange.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = configuration;
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
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
				var basePath = AppContext.BaseDirectory;
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
			app.UseStaticFiles();

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
