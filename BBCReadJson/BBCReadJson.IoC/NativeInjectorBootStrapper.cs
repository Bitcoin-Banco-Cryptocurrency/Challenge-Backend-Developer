using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BBCReadJson.Application.Interfaces;
using BBCReadJson.Application.Services;
using BBCReadJson.Domain.Interfaces;
using BBCReadJson.Infra.Data.Repositories;

namespace BBCReadJson.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IBookAppService, BookAppService>();

            // Infra - Data
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
