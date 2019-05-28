using BitCoinChallange.Domain.Kernel.Specifications;
using BitCoinChallange.Domain.Queries;
using System;
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
			return (a.Specifications.Author == b.Specifications.Author) ||
				   (a.Specifications.Illustrator == b.Specifications.Illustrator) ||
				   (a.Specifications.OriginallyPublished == b.Specifications.OriginallyPublished) ||
				   (a.Specifications.Genres.Any(w => b.Specifications.Genres.Any(any => any.Contains(w))));
		}
	}
}
