using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HepsiApi.PresisTence.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
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
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(7209), false, "Movies, Movies & Automotive" },
                    { 2, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(7226), false, "Computers, Clothing & Toys" },
                    { 3, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(7241), true, "Beauty, Kids & Industrial" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(8902), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(8904), false, "Moda", 0, 2 },
                    { 3, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(8905), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2025, 1, 20, 22, 49, 9, 600, DateTimeKind.Local).AddTicks(8907), false, "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 20, 22, 49, 9, 602, DateTimeKind.Local).AddTicks(3450), "Duyulmamış masanın odio otobüs aut.", false, "Sinema." },
                    { 2, 3, new DateTime(2025, 1, 20, 22, 49, 9, 602, DateTimeKind.Local).AddTicks(3487), "Olduğu fugit lakin magnam veritatis.", true, "Adipisci." },
                    { 3, 4, new DateTime(2025, 1, 20, 22, 49, 9, 602, DateTimeKind.Local).AddTicks(3515), "Yazın doğru adanaya voluptatem makinesi.", false, "Mi." }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 20, 22, 49, 9, 604, DateTimeKind.Local).AddTicks(4954), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1.803160940843090m, false, 692.75m, "Handmade Cotton Keyboard" },
                    { 2, 3, new DateTime(2025, 1, 20, 22, 49, 9, 604, DateTimeKind.Local).AddTicks(4985), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 4.742554099245720m, false, 899.69m, "Fantastic Wooden Salad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_details_CategoryId",
                table: "details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
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
                name: "details");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
