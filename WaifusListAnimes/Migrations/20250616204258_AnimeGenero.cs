using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaifusListAnimes.Migrations
{
    /// <inheritdoc />
    public partial class AnimeGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenero_Animes_AnimesId",
                table: "AnimeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenero_Generos_GenerosId",
                table: "AnimeGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeGenero",
                table: "AnimeGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animes",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "AnimesId",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.RenameTable(
                name: "Animes",
                newName: "Anime");

            migrationBuilder.RenameColumn(
                name: "GenerosId",
                table: "AnimeGenero",
                newName: "GeneroId");

            migrationBuilder.RenameColumn(
                name: "AnimesId",
                table: "AnimeGenero",
                newName: "AnimeId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeGenero_GenerosId",
                table: "AnimeGenero",
                newName: "IX_AnimeGenero_GeneroId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AnimeGenero",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeGenero",
                table: "AnimeGenero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anime",
                table: "Anime",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenero_AnimeId",
                table: "AnimeGenero",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenero_Anime_AnimeId",
                table: "AnimeGenero",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenero_Genero_GeneroId",
                table: "AnimeGenero",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenero_Anime_AnimeId",
                table: "AnimeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenero_Genero_GeneroId",
                table: "AnimeGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeGenero",
                table: "AnimeGenero");

            migrationBuilder.DropIndex(
                name: "IX_AnimeGenero_AnimeId",
                table: "AnimeGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anime",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AnimeGenero");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.RenameTable(
                name: "Anime",
                newName: "Animes");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "AnimeGenero",
                newName: "GenerosId");

            migrationBuilder.RenameColumn(
                name: "AnimeId",
                table: "AnimeGenero",
                newName: "AnimesId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeGenero_GeneroId",
                table: "AnimeGenero",
                newName: "IX_AnimeGenero_GenerosId");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimesId",
                table: "Generos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeGenero",
                table: "AnimeGenero",
                columns: new[] { "AnimesId", "GenerosId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animes",
                table: "Animes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenero_Animes_AnimesId",
                table: "AnimeGenero",
                column: "AnimesId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenero_Generos_GenerosId",
                table: "AnimeGenero",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
