using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Products.Data.JsonToData;
using Products.Models;
using Products.Data;

public static class Seeder
{

    public static void Seedit(IServiceProvider serviceProvider)
    {
        var json = System.IO.File.ReadAllText(@"books.json");
        var prods = JsonConvert.DeserializeObject<List<RootObject>>(json);
        List<Product> productsLst = new List<Product>();

            int idSpecification = 1;
        foreach (RootObject item in prods)
        {
            Product product = new Product()
            {
                ID = item.id,
                Name = item.name,
                Price = Convert.ToDecimal(item.price),
                SpecificationId = idSpecification,
                Specification = new Specification()
                {
                    Author = item.specifications.Author,
                    ID = idSpecification,
                    PageCount = item.specifications.Pagecount,
                    Published = Convert.ToDateTime(item.specifications.Published),
                    Genres = item.specifications.Genres.GetType().Equals(typeof(string)) ?
                            new string[] { (string)item.specifications.Genres } : ((JArray)item.specifications.Genres).Select(x => (string)x).ToArray(),
                    Illustrator = item.specifications.Illustrator.GetType().Equals(typeof(string)) ?
                            new string[] { (string)item.specifications.Illustrator } : ((JArray)item.specifications.Illustrator).Select(x => (string)x).ToArray(),
                }
            };
            idSpecification++;
            productsLst.Add(product);
        }

        using (
         var serviceScope = serviceProvider
            .GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<DataContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(productsLst);
                context.SaveChanges();
            }
        }
    }
}