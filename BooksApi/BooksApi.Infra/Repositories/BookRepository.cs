using BooksApi.Models;
using BooksApi.Models.Books;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BooksApi.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks()
        {
            using (StreamReader file = new StreamReader("./Data/data.json", Encoding.GetEncoding("iso-8859-1")))
            {
                string json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
    }
}
