using BooksApi.Models.Books;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BooksApi.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks()
        {
            string projectRootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var fullPath = projectRootPath + "\\Data\\data.json";
            using (StreamReader file = new StreamReader(fullPath, Encoding.GetEncoding("iso-8859-1")))
            {
                string json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
    }
}
