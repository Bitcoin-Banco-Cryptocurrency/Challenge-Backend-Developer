using System.Collections.Generic;

namespace BooksApi.Models.Books
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
    }
}