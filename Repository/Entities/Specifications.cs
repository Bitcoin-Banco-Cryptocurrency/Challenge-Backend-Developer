using System;
using Newtonsoft.Json;

namespace Repository.Entities
{
    public class Specifications
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("Originally published")]
        public DateTime OriginallyPublished { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("Page count")]
        public long PageCount { get; set; }

        [JsonProperty("Illustrator")]
        public StringOrArray Illustrator { get; set; }

        [JsonProperty("Genres")]
        public StringOrArray Genres { get; set; }

        /// <summary>
        /// Propriedade utilizada para filtro
        /// </summary>
        [JsonIgnore]
        public DateTime? PublishedMin { get; set; }

        /// <summary>
        /// Propriedade utilizada para filtro
        /// </summary>
        [JsonIgnore]
        public DateTime? PublishedMax { get; set; }

        /// <summary>
        /// Propriedade utilizada para filtro
        /// </summary>
        [JsonIgnore]
        public long PagesMin { get; set; }

        /// <summary>
        /// Propriedade utilizada para filtro
        /// </summary>
        [JsonIgnore]
        public long PagesMax { get; set; }
    }
}