using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileShop.Data.Migrations
{
    public partial class F6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "3407f00a-e64a-4e0e-898e-ceec0f8bc514");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c84d77a-e21d-41c7-9276-a1096851cb66", "AQAAAAEAACcQAAAAEMbCAEoHSSPe1HaUZNvpWXZE/Kr2N8oRv72uRUeuXGNJ00fofRvpSOZpJhkg5p29xA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 1, 24, 19, 24, 46, 806, DateTimeKind.Local).AddTicks(2967));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5ed15357-79ff-4217-b0bc-bdf5620c00a7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5420ce78-0236-4f50-8351-a70e791a2ee5", "AQAAAAEAACcQAAAAEBcdizPmMObZ2ef+aVXbjS/+dP7JED/P6GuybFjdpMsf0HRna+4HWyc+4SfENNSUCA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 12, 3, 19, 55, 21, 618, DateTimeKind.Local).AddTicks(7204));
        }
    }
}
