using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitCoinChallange.Domain.Queries
{
	public class BookSpecificationsResponse
	{
		[JsonProperty("Originally published")]
		public string OriginallyPublished { get; set; }

		[JsonProperty("Author")]
		public string Author { get; set; }

		[JsonProperty("Page count")]
		public int PageCount { get; set; }

		[JsonProperty("Illustrator")]
		public IEnumerable<string> Illustrator { get; set; }

		[JsonProperty("Genres")]
		public IEnumerable<string> Genres { get; set; }
	}
}
