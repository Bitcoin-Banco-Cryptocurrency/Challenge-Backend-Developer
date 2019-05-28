using AutoMapper;
using BitCoinChallange.Infra.CrossCutting.MapperConfigs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BitCoinChallange.Api.ApiConfigurations
{
	/// <summary>
	/// Classe stática de inicialização do automapper e profiles.
	/// este objeto precisa ser adicionado na startup da api.
	/// </summary>
	public static class AutoMapperSetup
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}
			services.AddAutoMapper(typeof(Startup));
			AutoMapperConfig.RegisterMappings();
		}
	}
}
