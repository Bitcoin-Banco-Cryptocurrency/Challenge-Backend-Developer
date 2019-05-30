using Domain.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	public class Product : BaseModel
	{
		[JsonProperty(PropertyName = "price")]
		public double Price { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		public int SpecificationId { get; set; }

		[JsonProperty(PropertyName = "specifications")]
		public virtual Specification Specifications { get; set; }
	}
}
