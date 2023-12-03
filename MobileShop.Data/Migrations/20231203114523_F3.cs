using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileShop.Data.Migrations
{
    public partial class F3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b0f39ff3-f588-4663-8dcf-a927af72b005");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4de08f4a-d69c-4147-a1aa-b415427f3fb9", "AQAAAAEAACcQAAAAEOcNoIK2jLF0OUx5dHprudaL16EjQgzYw5+/zIE2EXkyIp+gUOpM3MeDlPXPp2X1SQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 12, 3, 18, 45, 23, 140, DateTimeKind.Local).AddTicks(4733));
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
