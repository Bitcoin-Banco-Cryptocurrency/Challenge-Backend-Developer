using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Repository.Entities;

namespace Repository.Repositories
{
    public class ProductRepository
    {
        public List<Product> Get()
        {
            string arquivoJson = File.ReadAllText("..\\books.json");
            return JsonConvert.DeserializeObject<List<Product>>(arquivoJson, JsonHelper.Converter.Settings);
        }
    }
}