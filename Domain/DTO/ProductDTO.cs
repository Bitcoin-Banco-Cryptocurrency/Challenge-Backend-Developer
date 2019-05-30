using Domain.Base;

namespace Domain
{
	public class ProductDTO : BaseModel
	{
		public double Price { get; set; }
		public string Name { get; set; }
		public int SpecificationId { get; set; }
		public virtual SpecificationDTO Specifications { get; set; }
	}
}
