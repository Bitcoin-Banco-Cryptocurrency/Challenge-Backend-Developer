using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Challenge.API.DAL.Repository;
using Challenge.API.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Challenge.API.DAL.Impl
{
    public class BookRepository : IBookRepository
    {
        public List<Book> Data { get; set; }

        public BookRepository()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath += @"\book.json";
            Data = JsonConvert.DeserializeObject<List<Book>>(_filePath);
        }

        public void Filter(List<Expression<Func<Book, bool>>> filters)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetList()
        {
            throw new NotImplementedException();
        }

        public void OrderByPrice(Expression<Func<Book, float>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
