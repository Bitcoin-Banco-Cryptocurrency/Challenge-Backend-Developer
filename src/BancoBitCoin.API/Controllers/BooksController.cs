using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BancoBitCoin.Application.Interfaces;
using BancoBitCoin.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using BancoBitCoin.Domain.Dtos;

namespace BancoBitCoin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IMapper _mapper;

        public BooksController(IBookAppService bookAppService, IMapper mapper)
        {
            _bookAppService = bookAppService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<BookRequest> Get([FromQuery] BookRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _mapper.Map<IEnumerable<BookResponse>>(_bookAppService.GetBooks(request));

            if (!result.Any()) return NoContent();

            return Ok(result);
        }
    }
}