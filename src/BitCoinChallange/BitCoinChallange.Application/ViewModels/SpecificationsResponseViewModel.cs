using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitCoinChallange.Application.ViewModels
{
	public class SpecificationsResponseViewModel
	{
		[JsonProperty("Originally published")]
		public string OriginallyPublished { get; set; }

		[JsonProperty("Author")]
		public string Author { get; set; }

		[JsonProperty("Page count")]
		public int PageCount { get; set; }

		[JsonProperty("Illustrator")]
		public string Illustrator { get; set; }

		[JsonProperty("Genres")]
		public IEnumerable<string> Genres { get; set; }
	}
}
