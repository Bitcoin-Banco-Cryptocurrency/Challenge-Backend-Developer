using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonNet.PrivateSettersContractResolvers;

namespace Products.Data.JsonToData
{
    public class Specifications
    {
        public string Published { get; set; }
        public string Author { get; set; }
        public int Pagecount { get; set; }
        public object Illustrator { get; set; }
        public object Genres { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public Specifications specifications { get; set; }
    }
}