using BancoBitCoin.Domain.Dtos;
using BancoBitCoin.Domain.Entities;
using System.Collections.Generic;

namespace BancoBitCoin.Application.Interfaces
{
    public interface IBookAppService
    {
        IEnumerable<Book> GetBooks(BookRequest request);
    }
}
