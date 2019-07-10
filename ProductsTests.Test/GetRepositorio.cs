using Xunit;
using Products.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Products.Data;

namespace ProductsTests.Test
{
    public class GetRepositorio
    {
        public ProductRepository getProductRepository()
        {
            var services = new ServiceCollection();
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<ProductRepository, ProductRepository>();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<ProductRepository>();
        }

         public DataContext getDataContext()
        {
            var services = new ServiceCollection();
            services.AddScoped<DataContext, DataContext>();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<DataContext>();
        }
    }
}