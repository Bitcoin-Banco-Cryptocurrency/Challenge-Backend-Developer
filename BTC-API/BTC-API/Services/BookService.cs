using BTC_API.Models;
using BTC_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTC_API.Services
{
    public class BookService
    {
        public List<Book> GetAll()
        {
            return new BookRepository().GetAll();
        }
    }
}
