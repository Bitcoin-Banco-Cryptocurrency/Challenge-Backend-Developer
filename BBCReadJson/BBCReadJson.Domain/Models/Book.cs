using Newtonsoft.Json;

namespace BBCReadJson.Domain.Models
{
    public class Book
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("price")] public decimal Price { get; set; }

        [JsonProperty("specifications")] public Specifications Specifications { get; set; }
    }
}