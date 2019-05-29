using BitCoinChallange.Application.Interfaces;
using BitCoinChallange.Application.ViewModels;
using BitCoinChallange.Domain.Kernel.Handlers;
using BitCoinChallange.Domain.Kernel.Mappers;
using BitCoinChallange.Domain.Kernel.Queries;
using BitCoinChallange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitCoinChallange.Application.QueryStack
{
	public class BookQueryService : IBookQueryService
	{
		private readonly ICustomMapper _mapper;
		private readonly IMediatorHandler _memoryBus;

		public BookQueryService(ICustomMapper mapper, IMediatorHandler memoryBus)
		{
			_mapper = mapper;
			_memoryBus = memoryBus;
		}
		public PageResponse<BookResponseViewModel> GetAll(string ordering) => throw new System.NotImplementedException();

		public async Task<IEnumerable<BookQueryResponse>> GetByFilter(BookFilterViewModel filter)
		{
			var bookSpecifications = _mapper.Custom.Map<BookSpecificationsRequest>(filter.Specifications);
			var query = BookQueryRequest.Factory.Create(filter.Name, filter.Ordering, bookSpecifications);
			return await _memoryBus.SendQuery<BookQueryRequest, IEnumerable<BookQueryResponse>>(query);
		}

		public void Dispose() => GC.SuppressFinalize(this);
	}
}
