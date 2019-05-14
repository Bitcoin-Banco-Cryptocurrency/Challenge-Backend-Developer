using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Repository.Entities;

namespace Repository.Repositories
{
    public class ProductRepository
    {
        public string arquivoJson = File.ReadAllText("..\\books.json");
        public List<Product> Products => JsonConvert.DeserializeObject<List<Product>>(arquivoJson, JsonHelper.Converter.Settings);

        public List<Product> Get(Product product, bool priceAsc)
        {
            var filtroProducts = Products.Where
                (p =>
                    (string.IsNullOrEmpty(product.Name) || p.Name.StartsWith(product.Name)) &&
                    (string.IsNullOrEmpty(product.Specifications.Author) || p.Specifications.Author.StartsWith(product.Specifications.Author)) &&
                    (string.IsNullOrEmpty(product.Specifications.Genres.String) ||
                        (p.Specifications.Genres.String != null &&
                            p.Specifications.Genres.String.StartsWith(product.Specifications.Genres.String)
                        ) ||
                        (p.Specifications.Genres.StringArray != null &&
                            p.Specifications.Genres.StringArray.Where(g => g.StartsWith(product.Specifications.Genres.String)).Count() > 0
                        )
                    ) &&
                    (string.IsNullOrEmpty(product.Specifications.Illustrator.String) ||
                        (p.Specifications.Illustrator.String != null &&
                            p.Specifications.Illustrator.String.StartsWith(product.Specifications.Illustrator.String)
                        ) ||
                        (p.Specifications.Illustrator.StringArray != null &&
                            p.Specifications.Illustrator.StringArray.Where(g => g.StartsWith(product.Specifications.Illustrator.String)).Count() > 0
                        )
                    ) &&
                    (product.Specifications.PagesMin == 0 || p.Specifications.PageCount >= product.Specifications.PagesMin) &&
                    (product.Specifications.PagesMax == 0 || p.Specifications.PageCount <= product.Specifications.PagesMax) &&

                    (product.Specifications.PublishedMin == null || p.Specifications.OriginallyPublished >= product.Specifications.PublishedMin.Value) &&
                    (product.Specifications.PublishedMax == null || p.Specifications.OriginallyPublished <= product.Specifications.PublishedMax.Value)
                );

            return (priceAsc ? filtroProducts.OrderBy(p => p.Price) : filtroProducts.OrderByDescending(p => p.Price)).ToList();
        }
    }
}