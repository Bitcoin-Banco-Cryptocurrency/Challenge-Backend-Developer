using System.Collections.Generic;
using Catalogo.Aplicacao.Modelos;
using Newtonsoft.Json;

namespace Catalogo.Aplicacao.Queries
{
	public class CatalogoQuery : ICatalogoQuery
	{
		private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.None };
		private static readonly JsonSerializer _serializer = JsonSerializer.Create(_jsonSettings);
		private static readonly string _path = System.AppDomain.CurrentDomain.BaseDirectory + "books.json";

		public IEnumerable<Book> ObterLivros()
		{
			using (var reader = new System.IO.StreamReader(_path))
			using (var json = new JsonTextReader(reader))
			{
				return _serializer.Deserialize<IEnumerable<Book>>(json);
			}
		}
	}
}
