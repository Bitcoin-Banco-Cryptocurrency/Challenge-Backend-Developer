using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;


namespace Products.Controllers
{
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
        [Route("v1/specifications")]
        public IEnumerable<Specification> Get()
        {
            return _context.Specifications.AsNoTracking().ToList();
        }

        [Route("v1/specification/{id}")]
        [HttpGet]
        public Specification Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            return _context.Specifications.AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
        }

        [Route("v1/specification/{id}/products")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Product> GetProducts(int id)
        {
            //return _context.Products.AsNoTracking().Where(x => x.SpecificationId == id).ToList();
            return _context.Products.Include(spec => spec.Specification)
                .Where(x => x.SpecificationId == id)
                .ToList();
        }

        [Route("v1/specification")]
        [HttpPost]
        public Specification Post([FromBody]Specification specification)
        {
            _context.Specifications.Add(specification);
            _context.SaveChanges();

            return specification;
        }

        [Route("v1/specification")]
        [HttpPut]
        public Specification Put([FromBody]Specification specification)
        {
            _context.Entry<Specification>(specification).State = EntityState.Modified;
            _context.SaveChanges();

            return specification;
        }

        [Route("v1/specification")]
        [HttpDelete]
        public Specification Delete([FromBody]Specification specification)
        {
            _context.Specifications.Remove(specification);
            _context.SaveChanges();

            return specification;
        }
    }
}