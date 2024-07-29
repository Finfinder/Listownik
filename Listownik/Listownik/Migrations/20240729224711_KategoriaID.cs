using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listownik.Migrations
{
    /// <inheritdoc />
    public partial class KategoriaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KategoriaId",
                table: "WpisyListy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Kategorie_KategoriaId",
                table: "WpisyListy");

            migrationBuilder.DropIndex(
                name: "IX_WpisyListy_KategoriaId",
                table: "WpisyListy");

            migrationBuilder.DropColumn(
                name: "KategoriaId",
                table: "WpisyListy");
        }
    }
}
