using System.Collections.Generic;
using Newtonsoft.Json;

namespace BBCReadJson.Domain.Models
{
    public class Specifications
    {
        [JsonProperty("Originally published")] public string OriginallyPublished { get; set; }

        [JsonProperty("Author")] public string Author { get; set; }

        [JsonProperty("Page count")] public int PageCount { get; set; }

        [JsonProperty("Illustrator")] public IEnumerable<string> IllustratorList { get; set; }

        [JsonProperty("Genres")] public IEnumerable<string> GenresList { get; set; }
    }
}