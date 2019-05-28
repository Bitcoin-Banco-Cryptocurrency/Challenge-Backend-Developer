using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace BitCoinChallange.Domain.Kernel.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<T> Sort<T>(this IQueryable<T> source, string ordering)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (string.IsNullOrEmpty(ordering))
			{
				throw new ArgumentNullException("ordering");
			}

			source = source.OrderBy(ordering);

			return source;
		}
	}
}
