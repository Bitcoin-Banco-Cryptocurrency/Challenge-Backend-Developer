using MediatR;
using System.Threading.Tasks;

namespace BitCoinChallange.Domain.Kernel.Handlers
{
	public interface IMediatorHandler
	{
		Task<TResult> SendQuery<TQuery, TResult>(TQuery query)
			where TQuery : IRequest<TResult>
			where TResult : class;
	}
}
