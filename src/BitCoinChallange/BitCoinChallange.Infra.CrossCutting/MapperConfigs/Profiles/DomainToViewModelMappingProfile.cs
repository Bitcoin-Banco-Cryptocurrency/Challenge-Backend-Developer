using AutoMapper;

namespace BitCoinChallange.Infra.CrossCutting.MapperConfigs.Profiles
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<string, string>();
		}
	}
}
