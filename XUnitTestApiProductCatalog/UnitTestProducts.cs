using System;
using System.Linq;
using System.Globalization;
using Xunit;
using ApiProductCatalog.Controllers;
using Repository.Entities;

namespace XUnitTestApiProductCatalog
{
    public class UnitTestProducts
    {
        /// <summary>
        /// Teste para retornar todos os livros. Resultado deve ter 5 livros.
        /// </summary>
        [Fact]
        public void GetAllProducts()
        {
            var productsController = new ProductsController();
            var products = productsController.GetAllProducts();

            Assert.Equal(5, products.Count);
        }

        /// <summary>
        /// Teste para buscar pelo nome do livro começando com "Journey to the Center". Resultado deve ser apenas 1 livro.
        /// </summary>
        [Fact]
        public void GetProductByName()
        {
            var productsController = new ProductsController();
            var productFilter = new Product
            {
                Name = "Journey to the Center"
            };

            var products = productsController.GetProducts(productFilter, true);

            Assert.Single(products);
            Assert.StartsWith("Journey to the Center", products.First().Name);
        }

        /// <summary>
        /// Teste para buscar pelo nome do autor "J. K. Rowling", com ordenação descendente. Resultado deve conter 2 livros, sendo:
        /// 1- Fantastic Beasts and Where to Find Them: The Original Screenplay (Preço $11.15)
        /// 2- Harry Potter and the Goblet of Fire (Preço $7.31)
        /// </summary>
        [Fact]
        public void GetProductByAuthorOrderBrPriceDesc()
        {
            var productsController = new ProductsController();

            var productFilter = new Product
            {
                Specifications = new Specifications
                {
                    Author = "J. K. Rowling"
                }
            };

            var products = productsController.GetProducts(productFilter, false);

            Assert.Equal(2, products.Count);

            Assert.Equal("Fantastic Beasts and Where to Find Them: The Original Screenplay", products[0].Name);
            Assert.Equal("11.15", products[0].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("Harry Potter and the Goblet of Fire", products[1].Name);
            Assert.Equal("7.31", products[1].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        /// <summary>
        /// Teste para buscar pelo gênero "Adventure fiction", com ordenação ascendente. Resultado deve conter 3 livros, sendo:
        /// 1- The Lord of the Rings (Preço $6.15)
        /// 2- Journey to the Center of the Earth (Preço $10.00)
        /// 3- 20,000 Leagues Under the Sea (Preço $10.10)
        /// </summary>
        [Fact]
        public void GetProductByGenre()
        {
            var productsController = new ProductsController();

            var productFilter = new Product
            {
                Specifications = new Specifications
                {
                    Genres = new StringOrArray
                    {
                        String = "Adventure fiction"
                    }
                }
            };

            var products = productsController.GetProducts(productFilter, true);

            Assert.Equal(3, products.Count);

            Assert.Equal("The Lord of the Rings", products[0].Name);
            Assert.Equal("6.15", products[0].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("Journey to the Center of the Earth", products[1].Name);
            Assert.Equal("10.00", products[1].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("20,000 Leagues Under the Sea", products[2].Name);
            Assert.Equal("10.10", products[2].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        /// <summary>
        /// Teste para buscar pelo ilustrador "Édouard Riou", com ordenação ascendente. Resultado deve conter 2 livros, sendo:
        /// 1- Journey to the Center of the Earth (Preço $10.10)
        /// 2- 20,000 Leagues Under the Sea (Preço $10.10)
        /// </summary>
        [Fact]
        public void GetProductByIllustrator()
        {
            var productsController = new ProductsController();

            var productFilter = new Product
            {
                Specifications = new Specifications
                {
                    Illustrator = new StringOrArray
                    {
                        String = "Édouard Riou"
                    }
                }
            };

            var products = productsController.GetProducts(productFilter, true);

            Assert.Equal(2, products.Count);

            Assert.Equal("Journey to the Center of the Earth", products[0].Name);
            Assert.Equal("10.00", products[0].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("20,000 Leagues Under the Sea", products[1].Name);
            Assert.Equal("10.10", products[1].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        /// <summary>
        /// Teste para buscar livros que tenham entre 300 e 700 páginas. Resultado deve conter 2 livros, sendo:
        /// 1- Harry Potter and the Goblet of Fire
        /// 2- Fantastic Beasts and Where to Find Them: The Original Screenplay
        /// </summary>
        [Fact]
        public void GetProductByNumberOfPages()
        {
            var productsController = new ProductsController();

            var productFilter = new Product
            {
                Specifications = new Specifications
                {
                    PagesMin = 300,
                    PagesMax = 700
                }
            };

            var products = productsController.GetProducts(productFilter, true);

            Assert.Equal(2, products.Count);

            Assert.Equal("Harry Potter and the Goblet of Fire", products[0].Name);
            Assert.Equal("7.31", products[0].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("Fantastic Beasts and Where to Find Them: The Original Screenplay", products[1].Name);
            Assert.Equal("11.15", products[1].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        /// <summary>
        /// Teste para buscar livros que tenham sido publicados originalmente entre 01/01/1860 e 01/01/2000, com ordenação descendente.
        /// Resultado deve conter 3 livros, sendo:
        /// 1- 20,000 Leagues Under the Sea (Preço $10.10)
        /// 2- Journey to the Center of the Earth (Preço $10.10)
        /// 3- The Lord of the Rings (Preço $6.15)
        /// </summary>
        [Fact]
        public void GetProductByOriginallyPublishedOrderByPriceDesc()
        {
            var productsController = new ProductsController();

            var productFilter = new Product
            {
                Specifications = new Specifications
                {
                    PublishedMin = new DateTime(1860, 1, 1),
                    PublishedMax = new DateTime(2000, 1, 1),
                }
            };

            var products = productsController.GetProducts(productFilter, false);

            Assert.Equal(3, products.Count);

            Assert.Equal("20,000 Leagues Under the Sea", products[0].Name);
            Assert.Equal("10.10", products[0].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("Journey to the Center of the Earth", products[1].Name);
            Assert.Equal("10.00", products[1].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Assert.Equal("The Lord of the Rings", products[2].Name);
            Assert.Equal("6.15", products[2].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        /// <summary>
        /// Teste para buscar pelo nome do autor "J. K. Rowling" e gênero "Screenplay". Resultado deve conter 1 livros, sendo:
        /// 1- Fantastic Beasts and Where to Find Them: The Original Screenplay (Preço $11.15)
        /// </summary>
        [Fact]
        public void GetProductByAuthorAndGenre()
        {
            var productsController = new ProductsController();

            var productFilter = new Product
            {
                Specifications = new Specifications
                {
                    Author = "J. K. Rowling",
                    Genres = new StringOrArray
                    {
                        String = "Screenplay"
                    }
                }
            };

            var products = productsController.GetProducts(productFilter, false);

            Assert.Single(products);

            Assert.Equal("Fantastic Beasts and Where to Find Them: The Original Screenplay", products[0].Name);
            Assert.Equal("11.15", products[0].Price.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}
