using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileShop.Data.Migrations
{
    public partial class AlterTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SordOrder",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 10, 49, 7, 556, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 16, 10, 47, 8, 72, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SortOrder", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SortOrder", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 12, 16, 10, 49, 7, 564, DateTimeKind.Local).AddTicks(4778));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 10, 47, 8, 72, DateTimeKind.Local).AddTicks(8985),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 12, 16, 10, 49, 7, 556, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.AddColumn<int>(
                name: "SordOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SordOrder", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SordOrder", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 12, 16, 10, 47, 8, 81, DateTimeKind.Local).AddTicks(6131));
        }
    }
}
