using BitCoinChallange.Domain.Queries;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BitCoinChallange.Domain
{
	public class Books
	{
		public Books(IEnumerable<BookQueryResponse> items)
		{
			Items = items;
		}
		public IEnumerable<BookQueryResponse> Items { get; private set; }

		public static class FactoryBookJson
		{
			public static Books Create()
			{
				var json = ReadFileJson();
				var result = JsonConvert.DeserializeObject<IEnumerable<BookQueryResponse>>(json);
				return new Books(result);
			}

			private static string ReadFileJson()
			{
				var path = Directory.GetCurrentDirectory();
				var fullName = Path.Combine(path, "Books.json");
				var jsonResult = string.Empty;
				using (var r = new StreamReader(fullName))
				{
					jsonResult = r.ReadToEnd();
				}
				return jsonResult;
			}
		}
	}
}
