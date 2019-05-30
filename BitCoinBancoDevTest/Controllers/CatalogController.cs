using System.Collections.Generic;
using System.Threading.Tasks;
using BitCoinBancoDevTest.Interfaces;
using Domain;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BitCoinBancoDevTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalogController : ControllerBase
	{
		IProduct _productService;

		//ReadJson _readJson;
		public CatalogController(IProduct productService)
		{
			_productService = productService;
			//_readJson = new ReadJson(new FixStringJson(), new System.Net.WebClient());
		}

		// GET api/Catalog
		[AcceptVerbs("GET")]
		[EnableQuery()]
		[EnableCors]
		public Task<IList<ProductDTO>> GetCatalog()
		{
			var products = _productService.GetProductAsync();
			return products;
		}
	}
}
