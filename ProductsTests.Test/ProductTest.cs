using Xunit;
using Products.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Products.Data;
using Products.Models;
using System;

namespace ProductsTests.Test
{
    public class ProductTest : GetRepositorio
    {
        private readonly ProductRepository _repository;

        public ProductTest()
        {
           _repository = getProductRepository();
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


        [Fact]
        public void InsertProduct()
        {
            Specification spec = new Specification()
            {
                 ID = 32,
                 Author = "Jony Deep",
                 Genres = new string[]{"Science Fiction","Adventure fiction"},
                 Illustrator = new string[]{"Édouard Riou"},
                 Published = DateTime.Now,
                 PageCount = 34
            };
            
            Product product = new Product();
            product.ID = 6;
            product.Name = "Robin Hood 230";
            product.Price = new decimal(10.0);
            product.SpecificationId = 32;
            product.Specification = spec;

            var okResult = _repository.Save(product);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
