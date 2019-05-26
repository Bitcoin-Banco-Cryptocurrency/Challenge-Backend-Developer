using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BancoBitcoin.Repository.Entity
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            var jsonPath = System.Reflection.Assembly.GetEntryAssembly().Location + "books.json";

            using (StreamReader file = File.OpenText(jsonPath))
            {
                var serializer = new JsonSerializer();
                books = (List<Book>)serializer.Deserialize(file, typeof(Book));
            }

            return books;
        }
    }
}
