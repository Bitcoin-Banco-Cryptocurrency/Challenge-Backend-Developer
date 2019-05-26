using BancoBitcoin.Domain.Entity;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
    }
}
