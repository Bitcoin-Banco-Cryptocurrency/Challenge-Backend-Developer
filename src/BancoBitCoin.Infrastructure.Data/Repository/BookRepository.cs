using BancoBitCoin.Domain.Entities;
using BancoBitCoin.Domain.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BancoBitCoin.Infra.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            var books = JsonConvert.DeserializeObject<List<Book>>
                (File.ReadAllText("Data/books.json"));
            return books;
        }
    }
}
