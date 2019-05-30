using BancoBitcoin.Application.Interface;
using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using System.Collections.Generic;
using BancoBitcoin.Application.Util;
using System;

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
            var predicate = PredicateBuilder.True<Book>();
            Func<Book, bool> orderByFunc = x => true ;

            if (id != 0 || !string.IsNullOrEmpty(name) || price != 0)
            {
                if (id != 0)
                    predicate = predicate.And(x => x.Id == id);

                if (!string.IsNullOrEmpty(name))
                    predicate = predicate.And(x => x.Name.ToUpper().Contains(name.ToUpper()));

                if (price != 0)
                    predicate = predicate.And(x => x.Price.Equals(price));

                return _bookRepository.GetBooksBy(predicate.Compile(), order);
            }
            else
                return new List<Book>();
        }

        public IList<Book> GetBooksBy(string originallyPublished, string author, int pageCount, bool order)
        {
            var predicate = PredicateBuilder.True<Book>();

            if (!string.IsNullOrEmpty(originallyPublished) || !string.IsNullOrEmpty(author) || pageCount != 0)
            {
                if (!string.IsNullOrEmpty(originallyPublished))
                    predicate = predicate.And(x => x.Specifications.OriginallyPublished.ToUpper().Contains(originallyPublished.ToUpper()));

                if (!string.IsNullOrEmpty(author))
                    predicate = predicate.And(x => x.Specifications.Author.ToUpper().Contains(author.ToUpper()));

                if (pageCount > 0)
                    predicate = predicate.And(x => x.Specifications.PageCount == pageCount);

                return _bookRepository.GetBooksBy(predicate.Compile(), order);
            }
            else
                return new List<Book>();
        }
    }
}
