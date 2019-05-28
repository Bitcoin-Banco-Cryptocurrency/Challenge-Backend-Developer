using System.Collections.Generic;

namespace BitCoinChallange.Application.ViewModels
{
	public class BookFilterViewModel
	{
		public string Name { get; set; }
		public string Ordering { get; set; }
		public SpecificationViewModel Specifications { get; set; }
	}

	public class SpecificationViewModel
	{
		public string OriginallyPublished { get; set; }
		public string Author { get; set; }
		public int PageCount { get; set; }
		public string Illustrator { get; set; }
		public IList<GenresViewModel> Genres { get; set; }
	}

	public class GenresViewModel
	{
		public string Genre { get; set; }
	}
}
