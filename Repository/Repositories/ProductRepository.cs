using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

    //public partial class Product
    //{
    //    public static List<Product> FromJson(string json) => JsonConvert.DeserializeObject<List<Product>>(json, JsonHelper.Converter.Settings);
    //}

    //public static class Serialize
    //{
    //    public static string ToJson(this List<Product> self) => JsonConvert.SerializeObject(self, JsonHelper.Converter.Settings);
    //}
}