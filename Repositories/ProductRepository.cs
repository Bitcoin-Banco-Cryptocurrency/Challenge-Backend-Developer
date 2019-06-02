using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Product> Get()
        {
            return _context.Products.Include(spec => spec.Specification).AsNoTracking()
               .AsNoTracking()
               .ToList();
        }
        public Product Get(int id)
        {
            return _context.Products.Include(spec => spec.Specification).AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
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

        public IEnumerable<Product> Get(UrlQuery urlQuery)
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

            return listQuery;
        }

        public IEnumerable<Product> Get(string typeSort)
        {
            if (typeSort == "asc")
                return _context.Products.OrderBy(x => x.Price);
            else if(typeSort == "desc")
                return _context.Products.OrderByDescending(x => x.Price);

            return _context.Products.AsNoTracking();
        }
    }
}
