using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;

namespace Products.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public ActionResult Get()
        {
            try
            {

                var products = (_context.Products.Include(spec => spec.Specification).AsNoTracking()
                   .AsNoTracking()
                   .ToList());

                return new OkObjectResult(products);

            }
            catch (Exception er)
            {
                var result = new BadRequestObjectResult(new { message = er.InnerException.ToString(), currentDate = DateTime.Now });
                return result;
            }
        }
        public IActionResult Get(int id)
        {
            try
            {
                var product = _context.Products.Include(spec => spec.Specification).AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
                return new OkObjectResult(_context.Products.Include(spec => spec.Specification).AsNoTracking().Where(x => x.ID == id).FirstOrDefault());
            }
            catch (Exception erro)
            {
                var result = new BadRequestObjectResult(new { message = erro.InnerException.ToString(), currentDate = DateTime.Now });
                return result;
            }
        }
        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Deleted;
            _context.Products.Remove(product);
        }

        public IActionResult Get(UrlQuery urlQuery)
        {
            IEnumerable<Product> listQuery = _context.Products.Include(spec => spec.Specification);

            if (urlQuery.HaveFilter)
            {
                if (!string.IsNullOrEmpty(urlQuery.Genres))
                {
                    listQuery = listQuery.Where(q => q.Specification.Genres.Select(s => s.ToUpperInvariant()).ToList().Contains(urlQuery.Genres.ToUpperInvariant()));
                }
                if (!string.IsNullOrEmpty(urlQuery.Illustrator))
                {
                    listQuery = listQuery.Where(q => q.Specification.Illustrator.Select(s => s.ToUpperInvariant()).Contains(urlQuery.Illustrator.ToUpperInvariant()));
                }
                if (!string.IsNullOrEmpty(urlQuery.Author))
                {
                    listQuery = listQuery.Where(q => q.Specification.Author.ToUpperInvariant().Equals(urlQuery.Author.ToUpperInvariant()));
                }
                if (!string.IsNullOrEmpty(urlQuery.Published))
                {
                    listQuery = listQuery.Where(q => q.Specification.Published == Convert.ToDateTime(urlQuery.Published));
                }

            }
            if (urlQuery.SortPriceType == "asc")
                listQuery = listQuery.OrderBy(x => x.Price);
            else if (urlQuery.SortPriceType == "desc")
                listQuery = listQuery.OrderByDescending(x => x.Price);

            return new OkObjectResult(listQuery);
        }

        public IActionResult Get(string typeSort)
        {
            if (typeSort == "asc")
                return new OkObjectResult(_context.Products.OrderBy(x => x.Price));
            else if (typeSort == "desc")
                return new OkObjectResult(_context.Products.OrderByDescending(x => x.Price));

            return new OkObjectResult(_context.Products.AsNoTracking());
        }
    }
}
