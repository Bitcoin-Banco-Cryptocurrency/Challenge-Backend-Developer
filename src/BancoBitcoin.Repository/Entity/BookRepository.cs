using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using BancoBitcoin.Repository.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoBitcoin.Repository.Entity
{
    public class BookRepository : IBookRepository
    {
        private IList<Book> Books { get; set; }

        public BookRepository()
        {
            Books = ReadJson.GetDeserializedObjectsFromJsonFile<IList<Book>>("books.json");
        }

        public IList<Book> GetBooks()
        {
            return Books.ToList();
        }

        public IList<Book> GetBooksBy(Func<Book, bool> predicate, bool order)
        {
            var books = new List<Book>();            
            books = !order ? Books.Where(predicate).OrderBy(y => y.Price).ToList() : Books.Where(predicate).OrderByDescending(y => y.Price).ToList();
            return books;            
        }
    }
}
