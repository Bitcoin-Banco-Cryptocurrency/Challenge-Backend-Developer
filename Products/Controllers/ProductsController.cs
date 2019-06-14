using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;
using Products.Repositories;


namespace Products.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        // POST api/products/search
        [Route("v1/products/search")]
        [ResponseCache(Duration = 120)]
        public IEnumerable<Product> Get([FromBody]UrlQuery urlQuery)
        {
            return _repository.Get(urlQuery);
        }

        [HttpGet]
        // GET api/products
        [Route("v1/products")]
        [ResponseCache(Duration = 120)]
        public IActionResult Get()
        {
            var Products = _repository.Get();
            return Ok(Products);
        }

        [HttpGet]
        // GET api/products
        [Route("v1/products/{typeOrder}")]
        [ResponseCache(Duration = 120)]
        public IEnumerable<Product> Get(string typeOrder)
        {
            return _repository.Get(typeOrder);
        }

        [Route("v1/product/{id}")]
        [ResponseCache(Duration = 120)]
        [HttpGet]
        public Product Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            return _repository.Get(id);
        }

        [Route("v1/product")]
        [HttpPost]
        public Product Post([FromBody]Product produto)
        {
            _repository.Save(produto);
            return produto;
        }

        [Route("v1/product")]
        [HttpPut]
        public Product Put([FromBody]Product produto)
        {
            _repository.Update(produto);
            return produto;
        }

        [Route("v1/product")]
        [HttpDelete]
        public Product Delete([FromBody]Product produto)
        {
            _repository.Delete(produto);
            return produto;
        }
    }
}