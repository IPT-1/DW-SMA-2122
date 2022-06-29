using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMA_21296.Data.Migrations
{
    public partial class UtenteUserID_UsersUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "6a6b8985-e11d-4210-ab1b-4d00f8664797");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "5a1b752f-91ae-4e58-94ec-332b52225ac5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "p",
                column: "ConcurrencyStamp",
                value: "2b0770d4-5bee-4dc9-9c85-44b6d128f8fb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
