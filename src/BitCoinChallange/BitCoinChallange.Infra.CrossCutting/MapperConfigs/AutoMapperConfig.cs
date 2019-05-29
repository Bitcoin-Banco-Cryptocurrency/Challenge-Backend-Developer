using AutoMapper;
using BitCoinChallange.Infra.CrossCutting.MapperConfigs.Profiles;

namespace BitCoinChallange.Infra.CrossCutting.MapperConfigs
{
	public class AutoMapperConfig
	{
		public static MapperConfiguration RegisterMappings()
		{
			return new MapperConfiguration(cfg =>
			{
				cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
				cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
				cfg.AddProfile(new DomainToViewModelMappingProfile());
				cfg.AddProfile(new ViewModelToDomainMappingProfile());
			});
		}
	}
}
