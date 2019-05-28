using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace BitCoinChallange.Domain.Kernel.Queries
{
	public class PageResponse<T> : PageQueryResult<T> where T : class
	{
		public PageResponse(IEnumerable<T> items, string ordering) : base(items.AsQueryable(), ordering)
		{
			this.Ordering = ordering;
		}
		public string Ordering { get; set; }
	}
}