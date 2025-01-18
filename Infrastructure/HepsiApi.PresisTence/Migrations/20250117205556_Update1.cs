using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiApi.PresisTence.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_productCategories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productCategories_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(5315), "Computers, Industrial & Garden" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(5321), "Books" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(5327), "Games" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 17, 23, 55, 55, 936, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 938, DateTimeKind.Local).AddTicks(5601), "Aliquam batarya çünkü praesentium numquam.", "Filmini." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 938, DateTimeKind.Local).AddTicks(5681), "Çarpan voluptas quaerat gitti ipsam.", "İpsam." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 938, DateTimeKind.Local).AddTicks(5720), "Sıradanlıktan laboriosam sed mi un.", "Mıknatıslı." });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 940, DateTimeKind.Local).AddTicks(4514), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 5.425364807886990m, 736.86m, "Gorgeous Cotton Keyboard" });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 17, 23, 55, 55, 940, DateTimeKind.Local).AddTicks(4543), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 1.994088995443290m, 155.53m, "Intelligent Concrete Towels" });

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_CategoryId",
                table: "productCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productCategories");

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

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 444, DateTimeKind.Local).AddTicks(8756), "Beauty, Jewelery & Clothing" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 444, DateTimeKind.Local).AddTicks(8774), "Computers, Garden & Garden" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 444, DateTimeKind.Local).AddTicks(8779), "Clothing" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 23, 37, 9, 445, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 446, DateTimeKind.Local).AddTicks(3974), "Salladı odio quia qui autem.", "Et." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 446, DateTimeKind.Local).AddTicks(4003), "Bundan vel qui dolayı öyle.", "Gitti." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 446, DateTimeKind.Local).AddTicks(4036), "Commodi magnam dolorem voluptatem de.", "Suscipit." });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 447, DateTimeKind.Local).AddTicks(6691), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5.397703122667650m, 920.83m, "Handcrafted Granite Fish" });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 10, 23, 37, 9, 447, DateTimeKind.Local).AddTicks(6716), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 8.422036111385270m, 48.41m, "Handcrafted Frozen Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
