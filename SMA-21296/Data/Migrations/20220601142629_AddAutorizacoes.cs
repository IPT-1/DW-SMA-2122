using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMA_21296.Data.Migrations
{
    public partial class AddAutorizacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "d8413e90-4a00-45a1-8e4a-c0cf837bd13b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "464c3b67-1457-4adb-9260-2167497c3793");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "p",
                column: "ConcurrencyStamp",
                value: "c6ec428a-d998-4770-bc84-bda53279ab3f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "f342d602-86fb-4158-8365-25b984d772be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "227c2bb7-9cee-4a96-994d-8d6ab0c4bd2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "p",
                column: "ConcurrencyStamp",
                value: "9391a3d2-5bbb-49f5-be6a-8f0d116bf038");
        }
    }
}
