using BancoBitcoin.Application.Interface;
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

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

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

        /// <summary>
        /// Get books by information
        /// </summary>
        /// <param name="id">Id of the book</param>
        /// <param name="name">Name of the book</param>
        /// <param name="price">Price of the book</param>
        /// <param name="order">Order by asc = false and Order by desc = true</param>
        /// <response code="200">Result of the books</response>
        /// <response code="500">System Error</response>
        [HttpGet]
        [Route("GetBooksByInformation")]
        public ActionResult<IList<Book>> GetBooksByInformation(int id = 0, string name = "", decimal price = 0, bool order = false)
        {
            return _bookService.GetBooksBy(id, name, price, order) as List<Book>;
        }

        /// <summary>
        /// Get books by specification
        /// </summary>
        /// <param name="originallyPublished">Id of the book</param>
        /// <param name="author">Name of the book</param>
        /// <param name="pageCount">Price of the book</param>
        /// <param name="order">Order by asc = false and Order by desc = true</param>
        /// <response code="200">Result of the books</response>
        /// <response code="500">System Error</response>
        [HttpGet]
        [Route("GetBooksBySpecification")]
        public ActionResult<IList<Book>> GetBooksBySpecification(string originallyPublished = "", string author = "", int pageCount = 0, bool order = false)
        {
            return _bookService.GetBooksBy(originallyPublished, author, pageCount, order) as List<Book>;
        }
    }
}