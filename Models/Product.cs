using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Product
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID {get; set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SpecificationId {get; set;}
        public Specification Specification {get; set;}
    }
}