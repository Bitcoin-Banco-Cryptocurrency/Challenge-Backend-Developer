using BitCoinChallange.Domain.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
				var stringJson = JsonConvert.SerializeObject(json);
				var result = JsonConvert.DeserializeObject<IEnumerable<BookQueryResponse>>(stringJson);
				return new Books(result);
			}

			private static object ReadFileJson()
			{
				var path = Directory.GetCurrentDirectory();
				var fullName = Path.Combine(path, "Books.json");
				object jsonResult = new { };
				using (var json = File.OpenText(fullName))
				{
					var serializer = new JsonSerializer();
					object j = (object)serializer.Deserialize(json, typeof(object));
					jsonResult = j;
				}
				return jsonResult;
			}
		}
	}
}
