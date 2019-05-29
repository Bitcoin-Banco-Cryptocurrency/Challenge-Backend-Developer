using BitCoinChallange.Domain.Kernel.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitCoinChallange.Domain.Kernel.Queries
{
	public class PageResponse<T> : Message
	{
		public PageResponse(IEnumerable<T> items)
		{
			Data = items?.ToList();
		}
		public IReadOnlyList<T> Data { get; }
	}
}