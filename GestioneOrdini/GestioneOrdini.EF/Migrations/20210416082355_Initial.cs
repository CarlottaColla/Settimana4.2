using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneOrdini.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceCliente = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOrdine = table.Column<DateTime>(nullable: false),
                    CodiceOrdine = table.Column<string>(maxLength: 100, nullable: false),
                    CodiceProdotto = table.Column<string>(maxLength: 100, nullable: false),
                    Importo = table.Column<decimal>(nullable: false),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ordini_Clienti_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_ClienteID",
                table: "Ordini",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
