using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PristupPodacima.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupaID",
                table: "Klijent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_GrupaID",
                table: "Klijent",
                column: "GrupaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Grupe_GrupaID",
                table: "Klijent",
                column: "GrupaID",
                principalTable: "Grupe",
                principalColumn: "GrupaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Grupe_GrupaID",
                table: "Klijent");

            migrationBuilder.DropIndex(
                name: "IX_Klijent_GrupaID",
                table: "Klijent");

            migrationBuilder.DropColumn(
                name: "GrupaID",
                table: "Klijent");
        }
    }
}
