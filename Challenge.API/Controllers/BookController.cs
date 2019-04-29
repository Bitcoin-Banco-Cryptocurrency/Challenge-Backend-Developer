using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Book> Get(string Name, string AuthorName, bool PriceDesc)
        {
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
