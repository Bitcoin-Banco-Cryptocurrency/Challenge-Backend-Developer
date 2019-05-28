using BitCoinChallange.Domain.Kernel.Handlers;
using BitCoinChallange.Domain.Kernel.Mappers;
using BitCoinChallange.Domain.Kernel.Notifications;
using BitCoinChallange.Domain.Kernel.Queries;
using BitCoinChallange.Domain.Queries;
using BitCoinChallange.Domain.QueryHandler.Common;
using BitCoinChallange.Domain.Specifications;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitCoinChallange.Domain.QueryHandler
{
	public class QueryBooksHandler : BaseQueryHandler, IRequestHandler<BookQueryRequest, PageResponse<BookQueryResponse>>
	{
		private readonly ICustomMapper _mapper;
		private readonly IMediatorHandler _memoryBus;
		private readonly INotificationHandler<Notification> _notifications;

		public QueryBooksHandler(ICustomMapper mapper, IMediatorHandler memoryBus, INotificationHandler<Notification> notifications) : base(memoryBus, notifications)
		{
			_mapper = mapper;
			_memoryBus = memoryBus;
			_notifications = notifications;
		}

		public Task<PageResponse<BookQueryResponse>> Handle(BookQueryRequest request, CancellationToken cancellationToken)
		{
			request.ValidationResult = new ValidationResult();

			if (!request.IsValid())
			{
				NotifyValidationErrors(request);
				return null;
			}
			var spec = new BookFilterSpec();
			var books = Books.FactoryBookJson.Create();
			var queryResponse = _mapper.Custom.Map<List<BookQueryResponse>>(books.Items);
			var filter = queryResponse.Where(w => spec.IsSatisfiedBy(w, request));

			return Task.FromResult(new PageResponse<BookQueryResponse>(filter, request.Ordering));
		}
	}
}
