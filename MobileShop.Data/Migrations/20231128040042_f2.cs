using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileShop.Data.Migrations
{
    public partial class f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavigationMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationMenu", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "NavigationMenu",
                columns: new[] { "Id", "Alias", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, null, "", "Dashboard", null },
                    { 2, null, "", "Sản phẩm", null },
                    { 3, null, "", "Thêm sản phẩm", null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 28, 11, 0, 41, 878, DateTimeKind.Local).AddTicks(2903));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavigationMenu");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8bb1cf2d-2406-4a72-bb44-6ae92ae4315a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f25ad60f-5c57-45d3-8e8c-2133fadbfeeb", "AQAAAAEAACcQAAAAEMfOQd7hj37EyW67YCIgikku972G9qrKe/J4hJxED9kGdCP6nkIKWmJZ+IO/HhexMg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 19, 10, 36, 1, 172, DateTimeKind.Local).AddTicks(6478));
        }
    }
}
