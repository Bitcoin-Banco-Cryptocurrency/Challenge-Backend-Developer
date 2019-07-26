using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Models;

namespace Products.Data.Maps
{
    public class SpecificationMap : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.ToTable("Specification");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.PageCount).IsRequired();
            builder.Property(x => x.Published).IsRequired();
            builder.Property(x => x._genres).HasColumnName("Genres");
            builder.Property(x => x._illustrators).HasColumnName("Illustrator");
        }
    }
}