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

        public IList<Book> GetBooksByName(string name, bool order)
        {
            return _bookRepository.GetBooksByName(name, order);
        }

        public IList<Book> GetBooksBy(int id, string name, decimal price, bool order)
        {
            return _bookRepository.GetBooksBy(id, name, price, order);
        }
    }
}
