using BooksApi.Models.Books;
using System.Collections.Generic;

namespace BooksApi.Infra.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
    }
}