using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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

        public void Filter(List<Func<Book, bool>> filters)
        {
            foreach (var item in filters)
            {
                Data = Data.Where(item).ToList();
            }
        }

        public Book GetBookById(int Id)
        {
            return Data.SingleOrDefault(b => b.id == Id);
        }

        public List<Book> GetList()
        {
            return Data;
        }

        public void OrderByPrice()
        {
            Data.OrderBy(b => b.price);
        }
    }
}
