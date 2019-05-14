using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BBCReadJson.Application.Interfaces;
using BBCReadJson.Application.ViewModels;
using BBCReadJson.Domain.Interfaces;

namespace BBCReadJson.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookAppService(IMapper mapper,
            IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookViewModel> GetBooks(string search)
        {
            var list = _bookRepository.GetAll();

            var model = _mapper.Map<List<BookViewModel>>(list);

            //realizar o filtro
            //realizar o order by preço

            return model;
        }
    }
}
