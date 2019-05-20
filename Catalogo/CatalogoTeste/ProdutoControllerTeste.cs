using Catalogo.Aplicacao.Modelos;
using Catalogo.Aplicacao.Queries;
using Catalogo.Controllers;
using Catalogo.Modelo.Query;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CatalogoTeste
{
	public class ProdutoControllerTeste
	{
		private readonly Mock<ICatalogoQuery> _catalogoQueryMock;
		public ProdutoControllerTeste()
		{
			_catalogoQueryMock = new Mock<ICatalogoQuery>();
		}

		[Fact]
		public void Obter_Catalogo_Sucesso()
		{
			var fakeBookFilter = new BookQuery
			{
				Name = "Under the Sea"
			};

			_catalogoQueryMock
				.Setup(x => x.ObterLivros())
				.Returns(ObterFakeCatalogo());

			var produtoController = new ProdutosController();
			var actionResult = produtoController.Get(_catalogoQueryMock.Object, fakeBookFilter).ToList();

			Assert.NotNull(actionResult);
			Assert.True(actionResult.Any());

			var book = actionResult.Single();
			Assert.Equal(2, book.Id);
		}

		[Fact]
		public void Obter_CatalogoOrdenado_Sucesso()
		{
			var fakeBookFilter = new BookQuery
			{
				OrderBy = "desc"
			};

			_catalogoQueryMock
				.Setup(x => x.ObterLivros())
				.Returns(ObterFakeCatalogo());

			var produtoController = new ProdutosController();
			var actionResult = produtoController.Get(_catalogoQueryMock.Object, fakeBookFilter).ToList();

			Assert.NotNull(actionResult);
			Assert.Equal(3, actionResult.Count());

			Assert.True(actionResult.SequenceEqual(ObterFakeLivrosOrdenadosDesc(), new FakeBookEqualityComparer()));
		}

		private class FakeBookEqualityComparer : IEqualityComparer<Book>
		{
			public bool Equals(Book x, Book y) => x.Id == y.Id;

			public int GetHashCode(Book obj) => obj.Id.GetHashCode();
		}

		private static IEnumerable<Book> ObterFakeLivrosOrdenadosDesc()
		{
			return new List<Book>
			{
				new Book { Id = 2 },
				new Book { Id = 1 },
				new Book { Id = 3 },
			};
		}

		private static IEnumerable<Book> ObterFakeCatalogo()
		{
			return new List<Book>
			{
				new Book
				{
					Id = 1,
					Name = "Journey to the Center of the Earth",
					Price = 10.00,
					Specifications = new Specification
					{
						Originally = "November 25, 1864",
						Author = "Jules Verne",
						Pages = 183,
						Illustrator = new List<string> { "Édouard Riou" },
						Genres = new List<string>
						{
						  "Science Fiction",
						  "Adventure fiction"
						}
					}
				},

				new Book
				{
					Id = 2,
					Name = "20,000 Leagues Under the Sea",
					Price = 10.10,
					Specifications = new Specification
					{
						Originally = "June 20, 1870",
						Author = "Jules Verne",
						Pages = 213,
						Illustrator = new List<string>
						{
						   "Édouard Riou",
						   "Alphonse-Marie-Adolphe de Neuville"
						},
						Genres = new List<string> { "Adventure fiction" }
					}
				},
				new Book
				{
					Id = 3,
					Name = "Harry Potter and the Goblet of Fire",
					Price = 7.31,
					Specifications = new Specification
					{
						Originally = "July 8, 2000",
						Author = "J. K. Rowling",
						Pages = 636,
						Illustrator = new List<string>
						{
						   "Cliff Wright",
						   "Mary GrandPré"
						},
						Genres = new List<string>
						{
						  "Fantasy Fiction",
						  "Drama",
						  "Young adult fiction",
						  "Mystery",
						  "Thriller",
						  "Bildungsroman"
						}
					}
				}
			};
		}
	}
}