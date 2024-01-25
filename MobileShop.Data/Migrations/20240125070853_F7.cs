using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileShop.Data.Migrations
{
    public partial class F7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "3dbbb424-c717-418c-8768-ccca1cf6d4e6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81de20b8-9f23-48f6-b9fe-ac8e5bc7c720", "AQAAAAEAACcQAAAAEF00ko1LODOsYuqRTTXBl35UvwetzPNSr9/8pgIQXZMigjhZ+qowxSOKyNN2YtOHTg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 1, 25, 14, 8, 52, 888, DateTimeKind.Local).AddTicks(8349));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "83e0c99b-bce5-45c6-bbf9-b1116816d820");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e77ee70e-42b2-42a1-80ca-309380ab88a7", "AQAAAAEAACcQAAAAEK503aS9XNXkcSpMHJ509/BjJCN51eTHHqlNZm0dh/hYdMvIfJAZxstg8mUgM2e4WQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 28, 11, 0, 41, 878, DateTimeKind.Local).AddTicks(2903));
        }
    }
}
