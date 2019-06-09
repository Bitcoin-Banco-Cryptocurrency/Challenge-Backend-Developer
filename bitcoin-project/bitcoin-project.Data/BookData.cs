using bitcoin_project.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bitcoin_project.Data
{
    public class BookData : IBookData
    {
        private List<Book> DeserializeJson()
        {
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText("books.json"));
            return books;
        }

        public List<Book> Select()
        {
            var books = DeserializeJson();
            return books;
        }

        public List<Book> Select(Book book)
        {
            var books = DeserializeJson();

            List<Book> resultado = new List<Book>();

            foreach(Book b in books)
            {
                if
                    (b.Specifications.Author == book.Specifications.Author ||
                    b.Specifications.DateOfPublish == book.Specifications.DateOfPublish ||
                    b.Specifications.Genres.Any(book.Specifications.Genres.Contains) ||
                    b.Specifications.Illustrator.Any(book.Specifications.Illustrator.Contains) ||
                    b.Specifications.PageCount == book.Specifications.PageCount)
                    {
                        resultado.Add(b);
                    }
            }
            return resultado;
        }
    }
}
