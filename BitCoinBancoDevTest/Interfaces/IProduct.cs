using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitCoinBancoDevTest.Interfaces
{
	public interface IProduct
	{
		Task<IList<ProductDTO>> GetProductAsync();
		void SetProductAsync(List<Product> json);
		List<ProductDTO> ConvertProductDTO(List<Product> products);
		void LoadJsonData();
	}
}
