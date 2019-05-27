using BancoBitcoin.Domain.Entity;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Repository
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();

        IList<Book> GetBooksBy(int id, string name, decimal price, bool order);

        IList<Book> GetBooksBy(string originallyPublished, string author, int pageCount, bool order);
    }
}
