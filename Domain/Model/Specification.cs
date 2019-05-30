using Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	public class Specification : BaseModel
	{
		public string Author { get; set; }

		[JsonProperty(PropertyName = "Originally published")]
		public string OriginallyPublished { get; set; }

		[JsonProperty(PropertyName = "Page count")]
		public string PageCount { get; set; }

		public int GenreId { get; set; }

		[JsonProperty(PropertyName = "Genres")]
		public JToken GenreStringBroked { get; set; }

		public List<string> Genre { get; set; }

		[JsonProperty(PropertyName = "Illustrator")]
		public JToken IllustratorStringBroked { get; set; }

		public List<string> Illustrators { get; set; }
	}
}
