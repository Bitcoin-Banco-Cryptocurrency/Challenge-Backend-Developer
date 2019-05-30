using BancoBitCoin.Application.Interfaces;
using BancoBitCoin.Domain.Dtos;
using BancoBitCoin.Domain.Entities;
using BancoBitCoin.Domain.Interfaces.Application;
using System.Collections.Generic;
using System.Linq;

namespace BancoBitCoin.Application.Service
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookService _bookService;

        public BookAppService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<Book> GetBooks(BookRequest request)
        {
            Domain.Enums.Orderby orderby = request.OrderBy;
            IEnumerable<Book> result = _bookService.GetAll();

            // Todo: implement Specification pattern or CQRS
            if (request.Name != null)
                result = result.Where(b => b.Name.ToUpper().Contains(request.Name.ToUpper())).ToList();

            if (request.Author != null)
                result = result.Where(b => b.Specifications.Author.Contains(request.Author.ToUpper())).ToList(); ;


            // Todo: implement Strategy pattern           
            result = orderby == Domain.Enums.Orderby.ASC ? result.OrderBy(b => b.Price) :
                result.OrderByDescending(b => b.Price);

            return result;
        }
    }
}