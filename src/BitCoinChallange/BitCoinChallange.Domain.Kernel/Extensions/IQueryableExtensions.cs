using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BitCoinChallange.Domain.Kernel.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<T> Sort<T>(this IQueryable<T> source, string ordering)
		{
			if (source == null)
			{
				return default(IQueryable<T>);
			}

			if (string.IsNullOrEmpty(ordering))
			{
				return source;
			}

			source = source.OrderBy(ordering);

			return source;
		}
	}
}
