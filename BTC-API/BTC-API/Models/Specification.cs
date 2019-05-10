using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTC_API.Models
{
    public class Specification
    {
        public int Id { get; set; }

        public string Published { get; set; }

        public string Author { get; set; }

        public int PageCount { get; set; }

        public string Illustrator { get; set; }

        public virtual List<Genre> Genres { get; set; }
    }
}
