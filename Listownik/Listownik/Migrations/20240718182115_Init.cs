using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listownik.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WpisyListy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Ikona = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    KategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ListaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WpisyListy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WpisyListy_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WpisyListy_Listy_ListaId",
                        column: x => x.ListaId,
                        principalTable: "Listy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WpisyListy_KategoriaId",
                table: "WpisyListy",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_WpisyListy_ListaId",
                table: "WpisyListy",
                column: "ListaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WpisyListy");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Listy");
        }
    }
}
