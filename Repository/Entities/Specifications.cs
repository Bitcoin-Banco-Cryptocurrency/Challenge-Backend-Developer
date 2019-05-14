using Newtonsoft.Json;

namespace Repository.Entities
{
    public class Specifications
    {
        [JsonProperty("Originally published")]
        public string OriginallyPublished { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("Page count")]
        public long PageCount { get; set; }

        [JsonProperty("Illustrator")]
        public Genres Illustrator { get; set; }

        [JsonProperty("Genres")]
        public Genres Genres { get; set; }
    }
}