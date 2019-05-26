using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BancoBitcoin.Repository.Entity
{
    public class BookRepository : IBookRepository
    {
        public IList<Book> GetBooks()
        {
            var jsonPath = AppDomain.CurrentDomain.BaseDirectory + "books.json";
            string json = File.ReadAllText(jsonPath, Encoding.UTF8);            
            var books = JsonConvert.DeserializeObject<IList<Book>>(json);

            return books;
        }
    }
}
