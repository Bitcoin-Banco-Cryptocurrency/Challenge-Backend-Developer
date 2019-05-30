using BitCoinBancoDevTest.Interfaces;
using Domain;
using PopulateDataFromJson;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitCoinBancoDevTest.Services
{
	public class ProductService : IProduct
	{
		ReadJson _readJson;
		public ProductService()
		{
			_readJson = new ReadJson(new PopulateDataFromJson.Utils.FixStringJson(), new System.Net.WebClient());
			LoadJsonData();
		}
		public Task<IList<ProductDTO>> GetProductAsync()
		{
			using (RedisClient client = new RedisClient("10.5.0.6", 6379))
			{
				IRedisTypedClient<ProductDTO> product = client.As<ProductDTO>();
				return Task.FromResult(product.GetAll());
			}
		}
		public void SetProductAsync(List<Product> json)
		{
			using (RedisClient client = new RedisClient("10.5.0.6", 6379))
			{
				IRedisTypedClient<ProductDTO> product = client.As<ProductDTO>();
				var productsDto = ConvertProductDTO(json);
				product.StoreAll(productsDto);
			}
		}

		public List<ProductDTO> ConvertProductDTO(List<Product> products)
		{
			var productsDto = new List<ProductDTO>();
			foreach (var product in products)
			{
				var spectDto = new SpecificationDTO
				{
					Id = product.Specifications.Id,
					Author = product.Specifications.Author,
					Genres = product.Specifications.Genre,
					OriginallyPublished = product.Specifications.OriginallyPublished,
					PageCount = product.Specifications.PageCount,
					Illustrator = product.Specifications.Illustrators
				};

				var productDto = new ProductDTO
				{
					Id = product.Id,
					Name = product.Name,
					Price = product.Price,
					Specifications = spectDto
				};

				productsDto.Add(productDto);
			}
			return productsDto;
		}
		public void LoadJsonData()
		{
			List<Product> data = _readJson.GetData();
			SetProductAsync(data);
		}
	}
}
