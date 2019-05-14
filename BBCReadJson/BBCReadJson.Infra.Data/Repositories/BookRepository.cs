using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BBCReadJson.Domain.Interfaces;
using BBCReadJson.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BBCReadJson.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\books.json");

            var json = File.ReadAllText(path);

            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            foreach (var item in books)
            {
                var typeIllustratorObject = item.Specifications.IllustratorObject.GetType();

                if (typeIllustratorObject.Name.Equals("JArray"))
                    item.Specifications.IllustratorList.AddRange(JsonConvert.DeserializeObject<List<string>>(item.Specifications.IllustratorObject.ToString()));
                else
                    item.Specifications.IllustratorList.Add(item.Specifications.IllustratorObject.ToString());

                var typeGenresObject = item.Specifications.GenresObject.GetType();

                if (typeGenresObject.Name.Equals("JArray"))
                    item.Specifications.GenresList.AddRange(JsonConvert.DeserializeObject<List<string>>(item.Specifications.GenresObject.ToString()));
                else
                    item.Specifications.GenresList.Add(item.Specifications.GenresObject.ToString());
            }

            return books;
        }
    }
}
