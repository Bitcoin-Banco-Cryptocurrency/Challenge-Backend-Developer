using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;


namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        private readonly DataContext _context;

        public SpecificationsController(DataContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        // GET api/specifications
       
        public IEnumerable<Specification> Get()
        {
            return _context.Specifications.AsNoTracking().ToList();
        }

        [Route("specification/{id}")]
        [HttpGet]
        public Specification Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            return _context.Specifications.AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
        }

        [Route("specification/{id}/products")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.SpecificationId == id).ToList();
        }

        [Route("specification")]
        [HttpPost]
        public Specification Post([FromBody]Specification specification)
        {
            _context.Specifications.Add(specification);
            _context.SaveChanges();

            return specification;
        }

        [Route("specification")]
        [HttpPut]
        public Specification Put([FromBody]Specification specification)
        {
            _context.Entry<Specification>(specification).State = EntityState.Modified;
            _context.SaveChanges();

            return specification;
        }

        [Route("specification")]
        [HttpDelete]
        public Specification Delete([FromBody]Specification specification)
        {
            _context.Specifications.Remove(specification);
            _context.SaveChanges();

            return specification;
        }
    }
}