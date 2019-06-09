using System.Collections.Generic;

namespace bitcoin_project.Model
{
    public class Specifications
    {
        public string DateOfPublish { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public List<string> Illustrator { get; set; }
        public List<string> Genres { get; set; }            
           
    }
}