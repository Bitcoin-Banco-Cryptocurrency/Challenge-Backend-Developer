using BitCoinChallange.Domain.Kernel.Queries;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitCoinChallange.Domain.Queries
{
	public class BookQueryRequest : Query, IRequest<PageResponse<BookQueryResponse>>
	{
		public BookQueryRequest(string name, string ordering, BookSpecifications specifications)
		{
			Name = name;
			Ordering = ordering;
			Specifications = specifications;
		}

		public string Name { get; private set; }
		public string Ordering { get; private set; }
		public BookSpecifications Specifications { get; private set; }

		public override bool IsValid() => throw new System.NotImplementedException();
	}

	public class BookQueryResponse
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("price")]
		public double Price { get; set; }

		[JsonProperty("specifications")]
		public BookSpecifications Specifications { get; set; }
	}
}
