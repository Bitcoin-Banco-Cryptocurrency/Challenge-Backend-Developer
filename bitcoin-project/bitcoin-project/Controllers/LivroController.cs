using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitcoin_project.Service;
using Microsoft.AspNetCore.Mvc;


namespace bitcoin_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly IBookService _livroServices;

        public LivroController(IBookService livroServices)
        {
            _livroServices = livroServices;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var livro = _livroServices.Selecionar();
                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
