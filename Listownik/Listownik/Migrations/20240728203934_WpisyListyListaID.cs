﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listownik.Migrations
{
    /// <inheritdoc />
    public partial class WpisyListyListaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Listy_ListaId",
                table: "WpisyListy");

            migrationBuilder.AlterColumn<Guid>(
                name: "ListaId",
                table: "WpisyListy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WpisyListy_Listy_ListaId",
                table: "WpisyListy",
                column: "ListaId",
                principalTable: "Listy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WpisyListy_Listy_ListaId",
                table: "WpisyListy");

            migrationBuilder.AlterColumn<Guid>(
                name: "ListaId",
                table: "WpisyListy",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_WpisyListy_Listy_ListaId",
                table: "WpisyListy",
                column: "ListaId",
                principalTable: "Listy",
                principalColumn: "Id");
        }
    }
}
