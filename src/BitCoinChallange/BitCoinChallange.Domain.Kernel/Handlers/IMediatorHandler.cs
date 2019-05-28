using MediatR;
using System.Threading.Tasks;
using BitCoinChallange.Domain.Kernel.Events;

namespace BitCoinChallange.Domain.Kernel.Handlers
{
	public interface IMediatorHandler
	{
		Task RaiseEvent<TEvent>(TEvent @event) where TEvent : Event;

		Task<TResult> SendQuery<TQuery, TResult>(TQuery query)
			where TQuery : IRequest<TResult>
			where TResult : class;
	}
}
