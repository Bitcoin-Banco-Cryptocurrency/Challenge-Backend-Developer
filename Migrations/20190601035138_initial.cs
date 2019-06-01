using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Genres = table.Column<string>(nullable: true),
                    Illustrator = table.Column<string>(nullable: true),
                    Published = table.Column<DateTime>(nullable: false),
                    Author = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false),
                    PageCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    SpecificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Specification_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SpecificationId",
                table: "Product",
                column: "SpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Specification");
        }
    }
}
