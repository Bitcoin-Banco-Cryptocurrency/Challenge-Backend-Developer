using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
	public class BaseModel
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }
	}
}
