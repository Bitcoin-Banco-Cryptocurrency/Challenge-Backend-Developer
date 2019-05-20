using System;
using System.Collections.Generic;
using System.Linq;
using Catalogo.Aplicacao.Modelos;
using Catalogo.Aplicacao.Queries;
using Catalogo.Modelo.Query;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<Book> Get([FromServices] ICatalogoQuery catalogo, [FromQuery] BookQuery query)
		{
			var lista = Filtrar(catalogo.ObterLivros(), query);

			return OrdernadorPor(lista, query.OrderBy);
		}

		private static IEnumerable<Book> Filtrar(IEnumerable<Book> books, BookQuery query)
		{
			return books.Where(x =>
				(query.Id == null || x.Id == query.Id)
				&& (string.IsNullOrWhiteSpace(query.Name) || x.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase))
				&& (query.Price == null || x.Price == query.Price)
				&& (string.IsNullOrWhiteSpace(query.Author) || x.Specifications.Author.Contains(query.Author, StringComparison.OrdinalIgnoreCase))
				&& (query.Genres == null || x.Specifications.Genres.Any(a => query.Genres.Any(b => a.Contains(b, StringComparison.OrdinalIgnoreCase))))
				&& (query.Illustrator == null || x.Specifications.Illustrator.Any(a => query.Illustrator.Any(b => a.Contains(b, StringComparison.OrdinalIgnoreCase))))
				&& (string.IsNullOrWhiteSpace(query.Originally) || x.Specifications.Originally.Contains(query.Originally, StringComparison.OrdinalIgnoreCase))
				&& (query.Pages == null || x.Specifications.Pages == query.Pages)
			);
		}

		private static IEnumerable<Book> OrdernadorPor(IEnumerable<Book> books, string orderBy)
		{
			if ("asc".Equals(orderBy, StringComparison.OrdinalIgnoreCase))
				return books.OrderBy(x => x.Price);
			if ("desc".Equals(orderBy, StringComparison.OrdinalIgnoreCase))
				return books.OrderByDescending(x => x.Price);
			else
				return books;
		}
	}
}
