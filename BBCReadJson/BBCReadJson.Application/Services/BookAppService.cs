using System;
using System.Collections.Generic;
using System.Text;
using BBCReadJson.Application.Interfaces;
using BBCReadJson.Application.ViewModels;
using BBCReadJson.Domain.Interfaces;

namespace BBCReadJson.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookRepository _bookRepository;

        public BookAppService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookViewModel> GetBooks(string search)
        {
            var model = _bookRepository.GetAll();

            return null;
        }
    }
}
