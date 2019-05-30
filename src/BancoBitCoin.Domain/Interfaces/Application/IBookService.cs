using BancoBitCoin.Domain.Entities;
using System.Collections.Generic;

namespace BancoBitCoin.Domain.Interfaces.Application
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
    }
}
