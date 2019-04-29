using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Challenge.API.DAL.Repository;
using Challenge.API.Model;

namespace Challenge.API.DAL.Impl
{
    public class BookRepository : IBookRepository
    {
        public Book Data { get; set; }

        public BookRepository()
        {

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
