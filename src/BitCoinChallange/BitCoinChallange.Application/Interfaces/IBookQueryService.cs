using BitCoinChallange.Application.ViewModels;
using BitCoinChallange.Domain.Kernel.Queries;
using BitCoinChallange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitCoinChallange.Application.Interfaces
{
	public interface IBookQueryService : IDisposable
	{
		PageResponse<BookResponseViewModel> GetAll(string ordering);
		Task<IEnumerable<BookQueryResponse>> GetByFilter(BookFilterViewModel filter);
	}
}
