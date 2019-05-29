using Newtonsoft.Json;

namespace BitCoinChallange.Application.ViewModels
{
	public class BookResponseViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("price")]
		public double Price { get; set; }

		[JsonProperty("specifications")]
		public SpecificationsResponseViewModel Specifications { get; set; }
	}
}