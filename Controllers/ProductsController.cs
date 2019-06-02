using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;


namespace Products.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        // GET api/products
        [Route("v1/products")]
        public IEnumerable<Product> Get()
        {
            return _context.Products.Include(spec => spec.Specification).AsNoTracking().ToList();
        }

        [Route("v1/product/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            return _context.Products.Include(spec => spec.Specification).AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
        }

        [Route("v1/product")]
        [HttpPost]
        public Product Post([FromBody]Product produto)
        {
            _context.Products.Add(produto);
            _context.SaveChanges();

            return produto;
        }

        [Route("v1/product")]
        [HttpPut]
        public Product Put([FromBody]Product produto)
        {
            _context.Entry<Product>(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return produto;
        }

        [Route("v1/product")]
        [HttpDelete]
        public Product Delete([FromBody]Product produto)
        {
            _context.Products.Remove(produto);
            _context.SaveChanges();

            return produto;
        }
    }
}