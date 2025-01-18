using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiApi.PresisTence.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_products_ProductId",
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
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(2290), "Tools, Music & Home" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(2304), "Sports & Tools" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(2321), "Computers, Kids & Toys" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 40, 17, 528, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 529, DateTimeKind.Local).AddTicks(9816), "Quaerat gidecekmiş molestiae voluptatum telefonu.", "Exercitationem." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 529, DateTimeKind.Local).AddTicks(9847), "Orta yazın ut eaque nisi.", "Filmini." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 529, DateTimeKind.Local).AddTicks(9872), "Aliquid gitti koştum öyle nisi.", "Voluptatum." });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 532, DateTimeKind.Local).AddTicks(4297), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 1.346282350748620m, 137.98m, "Rustic Frozen Ball" });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 40, 17, 532, DateTimeKind.Local).AddTicks(4329), "The Football Is Good For Training And Recreational Purposes", 5.206753288829790m, 832.63m, "Awesome Wooden Keyboard" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

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
