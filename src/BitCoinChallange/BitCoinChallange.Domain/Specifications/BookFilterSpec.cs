using BitCoinChallange.Domain.Kernel.Specifications;
using BitCoinChallange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BitCoinChallange.Domain.Specifications
{
	public class BookFilterSpec : Specification<BookQueryResponse, BookQueryRequest>
	{
		public override Expression<Func<BookQueryResponse, BookQueryRequest, bool>> ToExpression()
		{
			return (a, b) => Rule(a, b);
		}

		private bool Rule(BookQueryResponse a, BookQueryRequest b)
		{
			var spec = b?.Specifications;

			return (!string.IsNullOrEmpty(b.Name) ? a.Name.Contains(b.Name) : false) ||
				   (!string.IsNullOrEmpty(b.Specifications.Author) ? a.Specifications.Author.Contains(b.Specifications.Author) : false) ||
				   (spec?.Illustrator != null ? spec.Illustrator.Any(any => a.Specifications.Illustrator.Contains(any)) : false) ||
				   (!string.IsNullOrEmpty(spec.OriginallyPublished) ? a.Specifications.OriginallyPublished.Contains(spec.OriginallyPublished) : false) ||
				   (spec?.Genres != null ? spec.Genres.Any(w => a.Specifications.Genres.Contains(w)) : false);
		}
	}
}
