using System;
using System.Collections.Generic;

namespace Products.Models
{
    public class Product
    {
        
        public int ID {get; set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SpecificationId {get; set;}
        public Specification Specification {get; set;}
    }
}