using AutoMapper;
using BancoBitCoin.Domain.Entities;
using BancoBitCoin.API.Models.Response;

namespace BancoBitCoin.API.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookResponse, Book>();
            CreateMap<Book, BookResponse>();
        }
    }
}
