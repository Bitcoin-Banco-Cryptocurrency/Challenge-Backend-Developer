using BancoBitcoin.Domain.Entity;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Repository
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();

        IList<Book> GetBooksByName(string name, bool order);

        IList<Book> GetBooksBy(int id, string name, decimal price, bool order);
    }
}
