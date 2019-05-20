namespace Catalogo.Aplicacao.Modelos
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public Specification Specifications { get; set; }
	}
}
