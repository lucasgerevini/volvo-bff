using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo.BFF.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "TEXT", nullable: false),
                    Permitido = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Sigla);
                });

            migrationBuilder.CreateTable(
                name: "Caminhoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnoFabricacao = table.Column<int>(type: "INTEGER", nullable: false),
                    AnoModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    SiglaModelo = table.Column<string>(type: "TEXT", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caminhoes_Modelos_SiglaModelo",
                        column: x => x.SiglaModelo,
                        principalTable: "Modelos",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Sigla", "Permitido" },
                values: new object[] { "FH", true });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Sigla", "Permitido" },
                values: new object[] { "FM", true });

            migrationBuilder.InsertData(
                table: "Caminhoes",
                columns: new[] { "Id", "AnoFabricacao", "AnoModelo", "DataExclusao", "SiglaModelo" },
                values: new object[] { 1, 2021, 2021, null, "FH" });

            migrationBuilder.InsertData(
                table: "Caminhoes",
                columns: new[] { "Id", "AnoFabricacao", "AnoModelo", "DataExclusao", "SiglaModelo" },
                values: new object[] { 2, 2021, 2022, null, "FM" });

            migrationBuilder.CreateIndex(
                name: "IX_Caminhoes_SiglaModelo",
                table: "Caminhoes",
                column: "SiglaModelo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhoes");

            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
