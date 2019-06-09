using System;

namespace bitcoin_project.Model
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Specifications Specifications { get; set; }    
          
    }
}