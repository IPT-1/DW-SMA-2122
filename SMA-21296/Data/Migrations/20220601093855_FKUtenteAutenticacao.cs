using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMA_21296.Data.Migrations
{
    public partial class FKUtenteAutenticacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Utentes");
        }
    }
}
