using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PristupPodacima.Migrations
{
    public partial class UpdateTrener : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Treneri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Treneri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Treneri");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Treneri");
        }
    }
}
