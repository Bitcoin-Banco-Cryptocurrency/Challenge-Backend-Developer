using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BBCReadJson.Domain.Models
{
    public class Specifications
    {
        public Specifications()
        {
            IllustratorList = new List<string>();
            GenresList = new List<string>();
        }

        [JsonProperty("Originally published")] public string OriginallyPublished { get; set; }

        [JsonProperty("Author")] public string Author { get; set; }

        [JsonProperty("Page count")] public int PageCount { get; set; }

        [JsonProperty("Illustrator")] public object IllustratorObject { get; set; }

        public List<string> IllustratorList { get; set; }

        [JsonProperty("Genres")] public object GenresObject { get; set; }

        public List<string> GenresList { get; set; }
    }
}