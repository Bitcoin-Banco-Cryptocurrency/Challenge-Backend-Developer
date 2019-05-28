using BitCoinChallange.Domain.Kernel.Handlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinChallange.Infra.CrossCutting
{
	public class MediatorHandler : IMediatorHandler
	{
		public Task<TResult> SendQuery<TQuery, TResult>(TQuery query)
			where TQuery : IRequest<TResult>
			where TResult : class => throw new NotImplementedException();
	}
}
