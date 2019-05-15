using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<BookViewModel> GetBooks(string search, string order)
        {
            var list = _bookRepository.GetAll();

            var model = _mapper.Map<List<BookViewModel>>(list);

            search = search.ToLower();

            var ret = model.Where(x =>
                x.Name.ToLower().Contains(search) ||
                x.Specifications.Author.ToLower().Contains(search) ||
                x.Specifications.Illustrator.Where(i => i.ToLower().Contains(search)).Any() ||
                x.Specifications.Genres.Where(i => i.ToLower().Contains(search)).Any());

            switch (order)
            {
                case "PriceASC":
                    ret = ret.OrderBy(x => x.Price);
                    break;
                case "PriceDESC":
                    ret = ret.OrderByDescending(x => x.Price);
                    break;
            }

            return ret;
        }
    }
}
