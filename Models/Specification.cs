using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class Specification
    {
        private static readonly char delimiter = ';';
        private string _genres;
        private string _illustrators;
        public int ID {get; set;}
        public DateTime Published {get; set;}
        public string Author { get; set; }
        public int PageCount { get; set; }

        [NotMapped]
        public string[] GenresList  
        {
        get { return _genres.Split(delimiter); }
        set
        {
            _genres = string.Join($"{delimiter}", value);
        }
        }
        [NotMapped]
        public string[] IllustratorsList  {
        get { return _illustrators.Split(delimiter); }
        set
        {
            _illustrators = string.Join($"{delimiter}", value);
        }
        }
        public IEnumerable<Product> Products { get; set; }
    }
}