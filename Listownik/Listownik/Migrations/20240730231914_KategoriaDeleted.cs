using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listownik.Migrations
{
    /// <inheritdoc />
    public partial class KategoriaDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Kategorie_KategoriaId",
                table: "WpisyListy");

            migrationBuilder.DropIndex(
                name: "IX_WpisyListy_KategoriaId",
                table: "WpisyListy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WpisyListy_KategoriaId",
                table: "WpisyListy",
                column: "KategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_WpisyListy_Kategorie_KategoriaId",
                table: "WpisyListy",
                column: "KategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
