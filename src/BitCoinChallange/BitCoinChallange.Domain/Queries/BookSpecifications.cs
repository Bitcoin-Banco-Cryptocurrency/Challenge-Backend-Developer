using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BitCoinChallange.Domain.Queries
{

	public class BookSpecifications
	{
		public BookSpecifications(string originallyPublished, string author, int pageCount, string illustrator, IEnumerable<string> genres)
		{
			this.OriginallyPublished = originallyPublished;
			this.Author = author;
			this.PageCount = pageCount;
			this.Illustrator = illustrator;
			this.Genres = genres;
		}

		[JsonProperty("Originally published")]
		public string OriginallyPublished { get; private set; }

		[JsonProperty("Author")]
		public string Author { get; private set; }

		[JsonProperty("Page count")]
		public int PageCount { get; private set; }

		[JsonProperty("Illustrator")]
		public string Illustrator { get; private set; }

		[JsonProperty("Genres")]
		public IEnumerable<string> Genres { get; private set; }
	}
}
