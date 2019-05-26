using System.Collections.Generic;

namespace BancoBitcoin.Domain.Entity
{
    public class Specification
    {
        public string OriginallyPublished { get; set; }

        public string Author { get; set; }

        public int PageCount { get; set; }

        public string Illustrator { get; set; }

        public List<string> Genres { get; set; }
    }
}