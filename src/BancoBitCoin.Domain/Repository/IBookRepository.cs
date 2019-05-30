using BancoBitCoin.Domain.Entities;
using System.Collections.Generic;

namespace BancoBitCoin.Domain.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
    }
}
