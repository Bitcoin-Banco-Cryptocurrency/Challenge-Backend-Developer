using BancoBitcoin.Domain.Entity;
using System.Collections.Generic;

namespace BancoBitcoin.Application.Interface
{
    public interface IBookService
    {
        List<Book> GetBooks();
    }
}
