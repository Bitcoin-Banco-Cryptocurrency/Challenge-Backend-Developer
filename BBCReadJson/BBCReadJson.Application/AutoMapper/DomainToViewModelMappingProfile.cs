using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BBCReadJson.Application.ViewModels;
using BBCReadJson.Domain.Models;

namespace BBCReadJson.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<Specifications, SpecificationsViewModel>()
            .ForMember(dest => dest.Genres,
            opts => opts.MapFrom(src => src.GenresList))
            .ForMember(dest => dest.Illustrator,
                opts => opts.MapFrom(src => src.IllustratorList));
        }
    }
}