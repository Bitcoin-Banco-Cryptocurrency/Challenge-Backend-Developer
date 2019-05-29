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
			var illustrator = b?.Specifications?.Illustrator;
			var genre = b?.Specifications?.Genres;

			return (a.Name == b.Name) ||
				   (a.Specifications.Author == b.Specifications?.Author) ||
				   (illustrator != null ? a.Specifications.Illustrator.Any(any => illustrator.Contains(any)) : false) ||
				   (a.Specifications.OriginallyPublished == b.Specifications?.OriginallyPublished) ||
				   (genre != null ? a.Specifications.Genres.Any(w => genre.Contains(w)) : false);
		}
	}
}
