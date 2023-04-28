using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PristupPodacima.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilaza = table.Column<int>(type: "int", nullable: false),
                    Visina = table.Column<int>(type: "int", nullable: false),
                    Pol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentID);
                });

            migrationBuilder.CreateTable(
                name: "Mesto",
                columns: table => new
                {
                    MestoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesto", x => x.MestoID);
                });

            migrationBuilder.CreateTable(
                name: "Obrazovanje",
                columns: table => new
                {
                    ObrazovanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepenObrazovanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obrazovanje", x => x.ObrazovanjeID);
                });

            migrationBuilder.CreateTable(
                name: "Treneri",
                columns: table => new
                {
                    TrenerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObrazovanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treneri", x => x.TrenerID);
                    table.ForeignKey(
                        name: "FK_Treneri_Obrazovanje_ObrazovanjeID",
                        column: x => x.ObrazovanjeID,
                        principalTable: "Obrazovanje",
                        principalColumn: "ObrazovanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grupe",
                columns: table => new
                {
                    GrupaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupaIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrenerID = table.Column<int>(type: "int", nullable: false),
                    MestoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupe", x => x.GrupaID);
                    table.ForeignKey(
                        name: "FK_Grupe_Mesto_MestoID",
                        column: x => x.MestoID,
                        principalTable: "Mesto",
                        principalColumn: "MestoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupe_Treneri_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Treneri",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupe_MestoID",
                table: "Grupe",
                column: "MestoID");

            migrationBuilder.CreateIndex(
                name: "IX_Grupe_TrenerID",
                table: "Grupe",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Treneri_ObrazovanjeID",
                table: "Treneri",
                column: "ObrazovanjeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupe");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Mesto");

            migrationBuilder.DropTable(
                name: "Treneri");

            migrationBuilder.DropTable(
                name: "Obrazovanje");
        }
    }
}
