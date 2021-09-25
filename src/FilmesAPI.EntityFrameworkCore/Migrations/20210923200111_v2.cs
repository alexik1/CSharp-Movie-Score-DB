using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Espectadores_AppFilmesAPI_FilmeId",
                table: "Filmes_Espectadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFilmesAPI",
                table: "AppFilmesAPI");

            migrationBuilder.RenameTable(
                name: "AppFilmesAPI",
                newName: "Filmes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Espectadores_Filmes_FilmeId",
                table: "Filmes_Espectadores",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Espectadores_Filmes_FilmeId",
                table: "Filmes_Espectadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "AppFilmesAPI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFilmesAPI",
                table: "AppFilmesAPI",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Espectadores_AppFilmesAPI_FilmeId",
                table: "Filmes_Espectadores",
                column: "FilmeId",
                principalTable: "AppFilmesAPI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
