using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Repository.Entities;
using Newtonsoft.Json;

namespace ApiProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]

        public List<Product> GetAllProducts()
        {
            var productService = new ProductService();
            return productService.Get(new Product(), true);
        }

        [HttpGet("{productFilters}")]
        public List<Product> GetProducts(Product productFilters, bool priceAsc)
        {
            var productService = new ProductService();
            return productService.Get(productFilters, priceAsc);
        }
    }
}