using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PristupPodacima.Migrations
{
    public partial class AddPol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pol",
                table: "Klijent",
                newName: "PolID");

            migrationBuilder.CreateTable(
                name: "Pol",
                columns: table => new
                {
                    PolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pol", x => x.PolID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_PolID",
                table: "Klijent",
                column: "PolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Pol_PolID",
                table: "Klijent",
                column: "PolID",
                principalTable: "Pol",
                principalColumn: "PolID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Pol_PolID",
                table: "Klijent");

            migrationBuilder.DropTable(
                name: "Pol");

            migrationBuilder.DropIndex(
                name: "IX_Klijent_PolID",
                table: "Klijent");

            migrationBuilder.RenameColumn(
                name: "PolID",
                table: "Klijent",
                newName: "Pol");
        }
    }
}
