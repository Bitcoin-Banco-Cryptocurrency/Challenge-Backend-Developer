using BitCoinChallange.Domain.Kernel.Events;
using BitCoinChallange.Domain.Kernel.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BitCoinChallange.Domain.Kernel.Queries
{
	public abstract class PageQueryResult<TEntity> where TEntity : class
	{
		public PageQueryResult(IQueryable<TEntity> items, string ordering)
		{
			Data = items?.Sort(ordering).ToList();
		}
		public IReadOnlyList<TEntity> Data { get; }
	}
}
