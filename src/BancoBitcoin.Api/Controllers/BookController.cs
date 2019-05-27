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

        // GET api/book/Harry Potter and the Goblet of Fire
        /// <summary>
        /// Get all the books
        /// </summary>
        /// <response code="200">Result of all the books</response>
        /// <response code="500">System Error</response>
        [HttpGet]
        [Route("GetBooks")]
        public ActionResult<IList<Book>> GetBooks()
        {
            return _bookService.GetBooks() as List<Book>;
        }

        // GET api/book/Harry Potter and the Goblet of Fire
        /// <summary>
        /// Get books by name
        /// </summary>
        /// <param name="name">Name of the book</param>
        /// <param name="order">Order by asc = false and Order by desc = true</param>
        /// <response code="200">Result of the book</response>
        /// <response code="500">System Error</response>
        [HttpGet]
        [Route("GetBooksByName")]
        public ActionResult<IList<Book>> GetBooksByName(string name = "", bool order = false)
        {
            return _bookService.GetBooksByName(name, order) as List<Book>;
        }

        // GET api/book/Harry Potter and the Goblet of Fire
        /// <summary>
        /// Get books by id, name or price
        /// </summary>
        /// <param name="id">Id of the book</param>
        /// <param name="name">Name of the book</param>
        /// <param name="price">Price of the book</param>
        /// <param name="order">Order by asc = false and Order by desc = true</param>
        /// <response code="200">Result of the books</response>
        /// <response code="500">System Error</response>
        [HttpGet]
        [Route("GetBooksBy")]
        public ActionResult<IList<Book>> GetBooksBy(int id = 0, string name = "", decimal price = 0, bool order = false)
        {
            return _bookService.GetBooksBy(id, name, price, order) as List<Book>;
        }
    }
}