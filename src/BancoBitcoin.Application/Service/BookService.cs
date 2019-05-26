using BancoBitcoin.Application.Interface;
using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using BancoBitcoin.Repository.Entity;
using System.Collections.Generic;

namespace BancoBitcoin.Application.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository { get; set; }

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public IList<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }
    }
}
