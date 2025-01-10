using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HepsiApi.PresisTence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_details_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 23, 37, 9, 444, DateTimeKind.Local).AddTicks(8756), false, "Beauty, Jewelery & Clothing" },
                    { 2, new DateTime(2025, 1, 10, 23, 37, 9, 444, DateTimeKind.Local).AddTicks(8774), false, "Computers, Garden & Garden" },
                    { 3, new DateTime(2025, 1, 10, 23, 37, 9, 444, DateTimeKind.Local).AddTicks(8779), true, "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(219), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(221), false, "Moda", 0, 2 },
                    { 3, new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(223), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(224), false, "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 10, 23, 37, 9, 446, DateTimeKind.Local).AddTicks(3974), "Salladı odio quia qui autem.", false, "Et." },
                    { 2, 3, new DateTime(2025, 1, 10, 23, 37, 9, 446, DateTimeKind.Local).AddTicks(4003), "Bundan vel qui dolayı öyle.", true, "Gitti." },
                    { 3, 4, new DateTime(2025, 1, 10, 23, 37, 9, 446, DateTimeKind.Local).AddTicks(4036), "Commodi magnam dolorem voluptatem de.", false, "Suscipit." }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 10, 23, 37, 9, 447, DateTimeKind.Local).AddTicks(6691), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5.397703122667650m, false, 920.83m, "Handcrafted Granite Fish" },
                    { 2, 3, new DateTime(2025, 1, 10, 23, 37, 9, 447, DateTimeKind.Local).AddTicks(6716), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 8.422036111385270m, false, 48.41m, "Handcrafted Frozen Chips" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_details_CategoryId",
                table: "details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_BrandId",
                table: "products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "details");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
