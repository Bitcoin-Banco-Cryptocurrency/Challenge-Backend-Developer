using Domain;
using Newtonsoft.Json;
using PopulateDataFromJson.Utils;
using System.Collections.Generic;
using System.Net;

namespace PopulateDataFromJson
{
	public class ReadJson
	{
		WebClient _wc;
		FixStringJson _fixStringsList;
		public ReadJson(FixStringJson fixStringsList, WebClient wc)
		{
			_fixStringsList = fixStringsList;
			_wc = wc;
		}

		public List<Product> GetData()
		{
			var jsonData = _wc.DownloadString("https://raw.githubusercontent.com/eduardomonteiro/NetCoreTest/master/BitCoinBancoDevTest/wwwroot/books.json");
			var data = JsonConvert.DeserializeObject<List<Product>>(jsonData);
			List<Product> products = new List<Product>();

			products = _fixStringsList.FixStringsList(data);

			return products;
		}

	}
}
