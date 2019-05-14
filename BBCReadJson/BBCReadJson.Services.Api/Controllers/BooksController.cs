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

        [HttpGet]
        [Route("/{search}")]
        public IActionResult GetBooks(string search)
        {
            try
            {
                return Ok(_bookAppService.GetBooks(search));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}