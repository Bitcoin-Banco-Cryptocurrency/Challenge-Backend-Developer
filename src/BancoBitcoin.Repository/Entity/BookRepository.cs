using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BancoBitcoin.Repository.Entity
{
    public class BookRepository : IBookRepository
    {
        private IList<Book> Books { get; set; }

        public BookRepository()
        {
            var jsonPath = AppDomain.CurrentDomain.BaseDirectory + "books.json";
            string json = File.ReadAllText(jsonPath, Encoding.UTF8);
            Books = JsonConvert.DeserializeObject<IList<Book>>(json);
        }

        public IList<Book> GetBooks()
        {
            return Books;
        }

        public IList<Book> GetBooksByName(string name, bool order)
        {
            if (!order && !string.IsNullOrEmpty(name))
                return Books.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).OrderBy(y => y.Price).ToList();
            else if (order && !string.IsNullOrEmpty(name))
                return Books.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).OrderByDescending(y => y.Price).ToList();
            else
            {
                IList<Book> books = new List<Book>();
                return books;
            }
        }

        public IList<Book> GetBooksBy(int id, string name, decimal price, bool order)
        {
            if (!order && (id != 0 || !string.IsNullOrEmpty(name) || price != 0))
            {
                if (string.IsNullOrEmpty(name))
                    return Books.Where(x => x.Id == id || x.Price.Equals(price)).OrderBy(y => y.Price).ToList();
                else
                    return Books.Where(x => x.Id == id && x.Name.ToUpper().Contains(name.ToUpper()) && x.Price.Equals(price)).OrderBy(y => y.Price).ToList();
            }
            else if (order && (id != 0 || !string.IsNullOrEmpty(name) || price != 0))
                return Books.Where(x => x.Id == id || x.Name.ToUpper().Contains(name.ToUpper()) || x.Price == price).OrderByDescending(y => y.Price).ToList();
            else
            {
                IList<Book> books = new List<Book>();
                return books;
            }
        }
    }
}
