using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiApi.PresisTence.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_categories_CategoryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_products_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "productCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "productCategories",
                newName: "IX_productCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productCategories",
                table: "productCategories",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(1082), "Industrial, Beauty & Electronics" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(1088), "Shoes" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(1095), "Sports" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 17, 55, 4, 668, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 669, DateTimeKind.Local).AddTicks(4475), "Vel sevindi nisi illo adipisci.", "Et." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 669, DateTimeKind.Local).AddTicks(4507), "Uzattı et yazın yazın beatae.", "Explicabo." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 669, DateTimeKind.Local).AddTicks(4536), "Velit qui karşıdakine quia architecto.", "Gazete." });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 671, DateTimeKind.Local).AddTicks(1850), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4.199097866194750m, 263.57m, "Handcrafted Cotton Pants" });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 17, 55, 4, 671, DateTimeKind.Local).AddTicks(1877), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 5.855766434930530m, 953.44m, "Rustic Metal Sausages" });

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_categories_CategoryId",
                table: "productCategories",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_products_ProductId",
                table: "productCategories",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_categories_CategoryId",
                table: "productCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_products_ProductId",
                table: "productCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productCategories",
                table: "productCategories");

            migrationBuilder.RenameTable(
                name: "productCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_productCategories_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_categories_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_products_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
