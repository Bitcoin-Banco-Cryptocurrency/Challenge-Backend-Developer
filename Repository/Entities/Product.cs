using Newtonsoft.Json;

namespace Repository.Entities
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("specifications")]
        public Specifications Specifications { get; set; }
    }
}