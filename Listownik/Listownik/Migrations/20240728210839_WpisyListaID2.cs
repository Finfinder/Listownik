using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listownik.Migrations
{
    /// <inheritdoc />
    public partial class WpisyListaID2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Kategorie_KategoriaId",
                table: "WpisyListy");

            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Listy_ListaId",
                table: "WpisyListy");

            migrationBuilder.DropIndex(
                name: "IX_WpisyListy_ListaId",
                table: "WpisyListy");

            migrationBuilder.RenameColumn(
                name: "KategoriaId",
                table: "WpisyListy",
                newName: "ListyEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_WpisyListy_KategoriaId",
                table: "WpisyListy",
                newName: "IX_WpisyListy_ListyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WpisyListy_Listy_ListyEntityId",
                table: "WpisyListy",
                column: "ListyEntityId",
                principalTable: "Listy",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Listy_ListyEntityId",
                table: "WpisyListy");

            migrationBuilder.RenameColumn(
                name: "ListyEntityId",
                table: "WpisyListy",
                newName: "KategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_WpisyListy_ListyEntityId",
                table: "WpisyListy",
                newName: "IX_WpisyListy_KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_WpisyListy_ListaId",
                table: "WpisyListy",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_WpisyListy_Kategorie_KategoriaId",
                table: "WpisyListy",
                column: "KategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WpisyListy_Listy_ListaId",
                table: "WpisyListy",
                column: "ListaId",
                principalTable: "Listy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
