using BooksApi.Domain.Models.Books;

namespace BooksApi.Models.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Specification Specifications { get; set; }
    }
}
