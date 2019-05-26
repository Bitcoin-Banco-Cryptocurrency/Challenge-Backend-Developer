using System;
using System.Collections.Generic;
using System.Text;

namespace BancoBitcoin.Domain.Entity
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<Specification> Specifications { get; set; }
    }
}
