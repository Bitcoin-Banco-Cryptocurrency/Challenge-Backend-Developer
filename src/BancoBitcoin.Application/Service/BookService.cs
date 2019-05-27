using BancoBitcoin.Application.Interface;
using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using System.Collections.Generic;

namespace BancoBitcoin.Application.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository { get; set; }

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IList<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }
        
        public IList<Book> GetBooksBy(int id, string name, decimal price, bool order)
        {
            return _bookRepository.GetBooksBy(id, name, price, order);
        }

        public IList<Book> GetBooksBy(string originallyPublished, string author, int pageCount, bool order)
        {
            return _bookRepository.GetBooksBy(originallyPublished, author, pageCount, order);
        }
    }
}
