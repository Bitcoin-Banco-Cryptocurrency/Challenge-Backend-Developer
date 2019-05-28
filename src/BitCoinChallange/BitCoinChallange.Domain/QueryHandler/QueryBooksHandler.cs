using BitCoinChallange.Domain.Kernel.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BitCoinChallange.Domain.QueryHandler
{
	public class QueryBooksHandler : IRequestHandler<Query<PageResponse<object>>, PageResponse<object>>
	{
		public Task<PageResponse<object>> Handle(Query<PageResponse<object>> request, CancellationToken cancellationToken) => throw new NotImplementedException();
	}
}
