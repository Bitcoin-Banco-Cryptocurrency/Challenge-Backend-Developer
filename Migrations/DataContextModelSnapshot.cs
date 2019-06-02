﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.Data;

namespace Products.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.Models.Product", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("SpecificationId");

                    b.HasKey("ID");

                    b.HasIndex("SpecificationId")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Products.Models.Specification", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<int>("PageCount");

                    b.Property<DateTime>("Published");

                    b.Property<string>("_genres")
                        .HasColumnName("Genres");

                    b.Property<string>("_illustrators")
                        .HasColumnName("Illustrator");

                    b.HasKey("ID");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("Products.Models.Product", b =>
                {
                    b.HasOne("Products.Models.Specification", "Specification")
                        .WithOne("Product")
                        .HasForeignKey("Products.Models.Product", "SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
