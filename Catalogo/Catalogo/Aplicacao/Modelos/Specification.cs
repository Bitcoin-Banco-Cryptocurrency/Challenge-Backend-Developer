using Catalogo.Aplicacao.Converters.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Catalogo.Aplicacao.Modelos
{
	public class Specification
	{
		[JsonProperty(PropertyName = "Originally published")]
		public string Originally { get; set; }
		public string Author { get; set; }
		[JsonProperty(PropertyName = "Page count")]
		public int Pages { get; set; }
		[JsonConverter(typeof(ArrayConverter<string>))]
		public IEnumerable<string> Illustrator { get; set; }
		[JsonConverter(typeof(ArrayConverter<string>))]
		public IEnumerable<string> Genres { get; set; }
	}
}
