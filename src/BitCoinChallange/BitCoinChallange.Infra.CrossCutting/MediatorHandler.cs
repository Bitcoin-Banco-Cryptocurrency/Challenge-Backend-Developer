using BitCoinChallange.Domain.Kernel.Events;
using BitCoinChallange.Domain.Kernel.Handlers;
using MediatR;
using System.Threading.Tasks;

namespace BitCoinChallange.Infra.CrossCutting
{
	public class MediatorHandler : IMediatorHandler
	{
		private readonly IMediator _mediator;

		public MediatorHandler(IMediator mediator)
		{
			_mediator = mediator;
		}

		public Task RaiseEvent<TEvent>(TEvent @event) where TEvent : Event => _mediator.Publish(@event);

		public Task<TResult> SendQuery<TQuery, TResult>(TQuery query)
			where TQuery : IRequest<TResult>
			where TResult : class => _mediator.Send(query);
	}
}
