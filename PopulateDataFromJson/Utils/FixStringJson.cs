using Domain;
using System.Collections.Generic;

namespace PopulateDataFromJson.Utils
{
	public class FixStringJson
	{
		public List<Product> FixStringsList(List<Product> products)
		{
			foreach (var productJson in products)
			{
				productJson.Specifications = FixGenre(productJson.Specifications);
				productJson.Specifications = FixIllustrator(productJson.Specifications);
			}
			return products;
		}

		public Specification FixGenre(Specification specification)
		{
			if (specification.GenreStringBroked.ToString().Contains('['))
			{
				specification.Genre = specification.GenreStringBroked.ToObject<List<string>>();
			}
			else
			{
				specification.Genre = new List<string>();
				specification.Genre.Add(specification.GenreStringBroked.ToObject<string>());
			}
			return specification;
		}

		public Specification FixIllustrator(Specification specification)
		{
			if (specification.IllustratorStringBroked.ToString().Contains('['))
			{
				specification.Illustrators = specification.IllustratorStringBroked.ToObject<List<string>>();
			}
			else
			{
				specification.Illustrators = new List<string>();
				specification.Illustrators.Add(specification.IllustratorStringBroked.ToObject<string>());
			}
			return specification;
		}
	}
}
