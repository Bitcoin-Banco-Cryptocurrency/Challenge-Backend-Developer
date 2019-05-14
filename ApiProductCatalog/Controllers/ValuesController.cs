﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Business.Services;

namespace ApiProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var productService = new ProductService();
            var product = new Repository.Entities.Product
            {
                // Name = "Journey",
                Specifications = new Repository.Entities.Specifications
                {
                    //Author = "Jules",
                    //Genres = new Repository.Entities.StringOrArray
                    //{
                    //    String = "Adventure"
                    //},
                    //Illustrator = new Repository.Entities.StringOrArray
                    //{
                    //    String = "Édouard"
                    //},
                    //PagesMin = 200,
                    //PagesMax = 300,
                    //PublishedMin = new DateTime(2000, 01, 01),
                    //PublishedMax = new DateTime(2000, 01, 01),
                }
            };

            var resultado = productService.Get(product, false);

            return new string[] { JsonConvert.SerializeObject(a, Repository.JsonHelper.Converter.Settings) };
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