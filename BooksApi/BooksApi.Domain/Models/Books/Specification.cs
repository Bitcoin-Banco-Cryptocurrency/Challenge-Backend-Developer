namespace BooksApi.Domain.Models.Books
{
    public class Specification
    {
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string[] Illustrator { get; set; }
        public string[] Genres { get; set; }
    }
}
