using BancoBitcoin.Domain.Entity;
using System;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Repository
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();

        IList<Book> GetBooksBy(Func<Book, bool> predicate, bool order);
    }
}
