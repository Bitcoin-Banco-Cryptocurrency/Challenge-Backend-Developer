using System.Collections.Generic;
using BitCoinChallange.Application.Interfaces;
using BitCoinChallange.Application.QueryStack;
using BitCoinChallange.Domain.Kernel.Handlers;
using BitCoinChallange.Domain.Kernel.Mappers;
using BitCoinChallange.Domain.Kernel.Notifications;
using BitCoinChallange.Domain.Kernel.Queries;
using BitCoinChallange.Domain.Queries;
using BitCoinChallange.Domain.QueryHandler;
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
			services.AddScoped<ICustomMapper, Mapping>();

			//Application - query
			services.AddScoped<IBookQueryService, BookQueryService>();
			services.AddScoped<IRequestHandler<BookQueryRequest, IEnumerable<BookQueryResponse>>, QueryBooksHandler>();

			// memory Bus (Mediator)
			services.AddScoped<IMediatorHandler, MediatorHandler>();

			//Kernel notifications
			services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
		}
	}
}
