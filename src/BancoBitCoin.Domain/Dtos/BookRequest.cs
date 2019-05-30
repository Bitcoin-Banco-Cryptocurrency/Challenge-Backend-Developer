using BancoBitCoin.Domain.Enums;

namespace BancoBitCoin.Domain.Dtos
{
    public class BookRequest
    {
        public Orderby OrderBy { get; set; } 
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
