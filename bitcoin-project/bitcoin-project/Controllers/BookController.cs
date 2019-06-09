using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitcoin_project.Model;
using bitcoin_project.Service;
using Microsoft.AspNetCore.Mvc;


namespace bitcoin_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookServices;

        public BookController(IBookService bookServices)
        {
            _bookServices = bookServices;
        }

        // GET api/values
        [HttpGet]
        [Route("/BuscarTodos")]
        public ActionResult Get()
        {
            try
            {
                var livro = _bookServices.Selecionar();
                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/BuscarPorSpecification")]
        public ActionResult BuscaPorSpec(Specifications spec)
        {
            try
            {
                Book book = new Book();
                book.Specifications = spec;
                var bookRetorno = _bookServices.SelecionarPorSpecifications(book);
                return Ok(bookRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/BuscarPorSpecificationASC")]
        public ActionResult BuscaPorSpecASC(Specifications spec)
        {
            try
            {
                Book book = new Book();
                book.Specifications = spec;
                var bookRetorno = _bookServices.SelecionarPorSpecificationOrdenarPrecoASC(book);
                return Ok(bookRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/BuscarPorSpecificationDSC")]
        public ActionResult BuscaPorSpecDSC(Specifications spec)
        {
            try
            {
                Book book = new Book();
                book.Specifications = spec;
                var bookRetorno = _bookServices.SelecionarPorSpecificationOrdenarPrecoDSC(book);
                return Ok(bookRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
