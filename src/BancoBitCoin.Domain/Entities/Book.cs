namespace BancoBitCoin.Domain.Entities
{
    public class Book
    {
        public Book(int id, string name, double price, Specification specifications)
        {
            Id = id;
            Name = name;
            Price = price;
            Specifications = specifications;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public Specification Specifications { get; private set; }
    }
}
