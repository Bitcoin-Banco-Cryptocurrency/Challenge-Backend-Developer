using Newtonsoft.Json;

namespace BitCoinChallange.Domain.Queries
{
	public class BookQueryResponse
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("price")]
		public double Price { get; set; }

		[JsonProperty("specifications")]
		public BookSpecificationsResponse Specifications { get; set; }
	}
}
