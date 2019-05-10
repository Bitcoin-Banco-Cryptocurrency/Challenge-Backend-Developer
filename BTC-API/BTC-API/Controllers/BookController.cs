using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTC_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BTC_API.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        [Route("api/book")]
        public IActionResult Get()
        {
            var result = new BookService().GetAll();
            return Ok(new {success = true, data = result });
        }
    }
}