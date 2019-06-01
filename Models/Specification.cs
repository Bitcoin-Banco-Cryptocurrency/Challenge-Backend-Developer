using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Products.Models
{
    public class Specification
    {
        [JsonIgnore]
        internal string _genres { get; set; }
        [JsonIgnore]
        internal string _illustrators { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Published")]
        public DateTime Published { get; set; }

        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "Pagecount")]
        public int PageCount { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "Genres")]
        public string[] Genres
        {
            get { return _genres == null ? null : JsonConvert.DeserializeObject<string[]>(_genres); }
            set { _genres = JsonConvert.SerializeObject(value); }
        }
        [NotMapped]
        [JsonProperty(PropertyName = "Illustrator")]
        public string[] Illustrator
        {
            get { return _illustrators == null ? null : JsonConvert.DeserializeObject<string[]>(_illustrators); }
            set { _illustrators = JsonConvert.SerializeObject(value); }
        }
        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}