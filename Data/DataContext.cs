using Microsoft.EntityFrameworkCore;
using Products.Models;
using Products.Data.Maps;


namespace Products.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=productDB;User ID=SA;password=@desafio2019");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
         builder.ApplyConfiguration(new ProductMap());
         builder.ApplyConfiguration(new SpecificationMap());
        }
    }
}