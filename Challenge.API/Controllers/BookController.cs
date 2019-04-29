using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Challenge.API.DAL.Impl;
using Challenge.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get(string Name, string AuthorName, bool orderBy)
        {
            List<Func<Book, bool>> filters = new List<Func<Book, bool>>();
            if (!String.IsNullOrEmpty(Name))
            {
                Func<Book, bool> name = b => b.name.Contains(Name);
                filters.Add(name);
            }

            if (!String.IsNullOrEmpty(Name))
            {
                Func<Book, bool> authorName = b => b.specifications.Author.Contains(AuthorName);
                filters.Add(authorName);
            }

            BookRepository bookRepository = new BookRepository();

            if (orderBy)
            {
                bookRepository.OrderByPrice();
            }

            return new BookRepository().GetList();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            return new BookRepository().GetBookById(id);
        }
    }
}
