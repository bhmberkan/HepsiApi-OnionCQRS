using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiApi.PresisTence.Migrations
{
    /// <inheritdoc />
    public partial class updatess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(3326), "Toys" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(3362), "Baby & Electronics" });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(3374), "Music & Games" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 18, 24, 8, 930, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 931, DateTimeKind.Local).AddTicks(6869), "Dolores çarpan enim açılmadan öyle.", "Veniam." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 931, DateTimeKind.Local).AddTicks(6900), "Eum aut ipsum vel veritatis.", "Yazın." });

            migrationBuilder.UpdateData(
                table: "details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 931, DateTimeKind.Local).AddTicks(6964), "Autem dergi camisi teldeki praesentium.", "Işık." });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 933, DateTimeKind.Local).AddTicks(4726), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 8.587906070479380m, 797.70m, "Practical Plastic Keyboard" });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 1, 18, 18, 24, 8, 933, DateTimeKind.Local).AddTicks(4753), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 1.423414912539980m, 932.16m, "Gorgeous Fresh Fish" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
