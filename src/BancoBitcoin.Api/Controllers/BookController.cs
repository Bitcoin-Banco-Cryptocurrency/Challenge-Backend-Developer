using BancoBitcoin.Application.Interface;
using BancoBitcoin.Application.Service;
using BancoBitcoin.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoBitcoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookService _bookService { get; set; }

        public BookController()
        {
            _bookService = new BookService();
        }

        // GET api/book
        [HttpGet]
        public ActionResult<IList<Book>> GetBooks()
        {
            return _bookService.GetBooks() as List<Book>;
        }
    }
}