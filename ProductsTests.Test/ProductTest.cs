using Xunit;
using Products.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Products.Data;

namespace ProductsTests.Test
{
    public class ProductTest
    {
        private readonly ProductRepository _repository;

        public ProductTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<ProductRepository, ProductRepository>();
            var serviceProvider = services.BuildServiceProvider();
            _repository = serviceProvider.GetService<ProductRepository>();
        }


        [Fact]
        public void GetAll()
        {
            var okResult = _repository.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData(1)]
        public void GetAllId(int value)
        {
            var okResult = _repository.Get(value);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
