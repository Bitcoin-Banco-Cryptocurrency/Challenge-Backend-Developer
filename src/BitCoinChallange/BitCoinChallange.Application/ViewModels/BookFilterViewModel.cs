using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BitCoinChallange.Application.ViewModels
{
	/// <summary>
	/// Model para filtrar o resultado.
	/// </summary>
	public class BookFilterViewModel
	{
		[Display(Name = "Nome do livro", Order = 1, Prompt = "digite o nome do ivro", Description = "Nome do livro")]
		public string Name { get; set; }

		/// <summary>
		/// Defina a ordenação por preço preenchendo o campo com <param name="ASC"></param>
		/// ou <param name="DESC"></param>
		/// </summary>
		[DisplayName("Ordenação por peço")]
		public string Ordering { get; set; }

		[DisplayName("Especificações do livro")]
		public SpecificationViewModel Specifications { get; set; }
	}

	/// <summary>
	/// especificações dos livros para filtro
	/// </summary>
	public class SpecificationViewModel
	{
		[DisplayName("Publicação")]
		public string OriginallyPublished { get; set; }

		[DisplayName("Autor")]
		public string Author { get; set; }

		[DisplayName("número de páginas")]
		public int PageCount { get; set; }

		[DisplayName("Ilustrador")]
		public IEnumerable<string> Illustrator { get; set; }

		[DisplayName("Gênero")]
		public IEnumerable<string> Genres { get; set; }
	}
}
