using Newtonsoft.Json;

namespace BancoBitCoin.Domain.Entities
{
    public class Specification
    {
        public Specification(string originallyPublished, string author, short pageCount, string[] illustrator, string[] genres)
        {
            OriginallyPublished = originallyPublished;
            Author = author;
            PageCount = pageCount;
            Illustrator = illustrator;
            Genres = genres;
        }

        [JsonProperty(PropertyName = "Originally Published")]
        public string OriginallyPublished { get; private set; }
        public string Author { get; private set; }
        [JsonProperty(PropertyName = "Page Count")]
        public short PageCount { get; private set; }
        public string[] Illustrator { get; private set; }
        public string[] Genres { get; private set; }
    }
}
