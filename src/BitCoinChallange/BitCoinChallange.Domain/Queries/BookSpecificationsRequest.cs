using System.Collections.Generic;

namespace BitCoinChallange.Domain.Queries
{

	public class BookSpecificationsRequest
	{
		public BookSpecificationsRequest(string originallyPublished, string author, int pageCount, IEnumerable<string> illustrator, IEnumerable<string> genres)
		{
			this.OriginallyPublished = originallyPublished;
			this.Author = author;
			this.PageCount = pageCount;
			this.Illustrator = illustrator;
			this.Genres = genres;
		}
		public string OriginallyPublished { get; private set; }

		public string Author { get; private set; }

		public int PageCount { get; private set; }

		public IEnumerable<string> Illustrator { get; private set; }

		public IEnumerable<string> Genres { get; private set; }
	}
}
