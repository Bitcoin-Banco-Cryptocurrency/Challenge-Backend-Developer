using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BBCReadJson.Domain.Interfaces;
using BBCReadJson.Domain.Models;
using Newtonsoft.Json;

namespace BBCReadJson.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\books.json");

            var json = File.ReadAllText(path);

            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            return books;
        }
    }
}
