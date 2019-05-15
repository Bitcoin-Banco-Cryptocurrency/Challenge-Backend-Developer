using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBCReadJson.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBCReadJson.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookAppService _bookAppService;

        public BooksController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        /// <summary>
        /// Get books from json.
        /// </summary>
        /// <param name="search">Search by Name, Author, Illustrator and Genres.</param>
        /// <param name="order">Order by PriceASC or PriceDESC.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/search/{search?}/order/{order?}")]
        public IActionResult GetBooks(string search = "", string order = "PriceASC")
        {
            try
            {
                return Ok(_bookAppService.GetBooks(search, order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}