using Domain.Base;
using System.Collections.Generic;

namespace Domain
{
	public class SpecificationDTO : BaseModel
	{
		public string Author { get; set; }

		public string OriginallyPublished { get; set; }

		public string PageCount { get; set; }

		public List<string> Genres { get; set; }
		public List<string> Illustrator { get; set; }
	}
}
