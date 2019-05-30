using BancoBitCoin.Domain.Entities;
using BancoBitCoin.Domain.Interfaces.Application;
using BancoBitCoin.Domain.Repository;
using System.Collections.Generic;

namespace BancoBitCoin.Domain.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
    }
}
