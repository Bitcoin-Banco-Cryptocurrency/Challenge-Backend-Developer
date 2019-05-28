using AutoMapper;
using BitCoinChallange.Domain.Kernel.Handlers;
using BitCoinChallange.Domain.Kernel.Mappers;
using BitCoinChallange.Domain.Kernel.Queries;
using BitCoinChallange.Infra.CrossCutting.MapperConfigs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BitCoinChallange.Infra.CrossCutting.Ioc
{
	public class InjectNative
	{
		public static void RegisterServices(IServiceCollection services)
		{
			//automapper
			services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
			services.AddSingleton(Mapper.Configuration);
			services.AddScoped<ICustomMapper, Mapping>();

			//Application - query
			services.AddScoped<IRequestHandler<Query<PageResponse<>>, PageResponse<>>, QueryBooksHandler>();

			// Domain Bus (Mediator)
			services.AddScoped<IMediatorHandler, MediatorHandler>();

			// Domain Specifications
			//services.AddScoped<IInspecaoRules, InspecaoRules>();
		}
	}
}
