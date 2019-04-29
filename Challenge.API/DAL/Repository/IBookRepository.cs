using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Challenge.API.Model;

namespace Challenge.API.DAL.Repository
{
    public interface IBookRepository
    {
        void Filter(List<Func<Book, bool>> filters);
        void OrderByPrice();
        List<Book> GetList();
        Book GetBookById(int id);
    }
}
