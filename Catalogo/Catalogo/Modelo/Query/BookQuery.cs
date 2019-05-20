using System.Collections.Generic;

namespace Catalogo.Modelo.Query
{
	public class BookQuery
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public double? Price { get; set; }
		public string Originally { get; set; }
		public string Author { get; set; }
		public int? Pages { get; set; }
		public IEnumerable<string> Illustrator { get; set; }
		public IEnumerable<string> Genres { get; set; }
		public string OrderBy { get; set; }
	}
}
