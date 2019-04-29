using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.API.Model
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public Specifications specifications { get; set; }

        public class Specifications
        {
            public string Originallypublished { get; set; }
            public string Author { get; set; }
            public int Pagecount { get; set; }
            public string Illustrator { get; set; }
            public string[] Genres { get; set; }
        }

    }
}
