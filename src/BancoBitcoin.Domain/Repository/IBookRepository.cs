using BancoBitcoin.Domain.Entity;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Repository
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();
    }
}
