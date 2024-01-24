using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileShop.Data.Migrations
{
    public partial class f5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
