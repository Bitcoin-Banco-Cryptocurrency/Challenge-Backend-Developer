using System.Collections.Generic;
using Repository.Entities;
using Repository.Repositories;

namespace Business.Services
{
    /// <summary>
    /// Classe para aplicação das regras de negócio do produto (Quando houver)
    /// </summary>
    public class ProductService
    {
        public List<Product> Get(Product product, bool priceAsc)
        {
            return new ProductRepository().Get(product, priceAsc);
        }
    }
}