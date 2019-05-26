using BancoBitcoin.Domain.Util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Entity
{
    //[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Specification
    {
        [JsonProperty("Originally published")]
        public string OriginallyPublished { get; set; }

        public string Author { get; set; }

        [JsonProperty("Page count")]
        public int PageCount { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<string>))]
        public IList<string> Illustrator { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<string>))]
        public IList<string> Genres { get; set; }
    }
}