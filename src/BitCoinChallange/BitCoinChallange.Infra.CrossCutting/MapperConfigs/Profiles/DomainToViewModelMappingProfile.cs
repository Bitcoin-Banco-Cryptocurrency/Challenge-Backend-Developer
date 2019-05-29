using AutoMapper;
using BitCoinChallange.Application.ViewModels;
using BitCoinChallange.Domain.Queries;

namespace BitCoinChallange.Infra.CrossCutting.MapperConfigs.Profiles
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<BookQueryResponse, BookResponseViewModel>();
		}
	}
}