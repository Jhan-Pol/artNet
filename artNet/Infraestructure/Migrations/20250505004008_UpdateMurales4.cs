using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMurales4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Murales_Artista_ArtistaId1",
                table: "Murales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artista",
                table: "Artista");

            migrationBuilder.RenameTable(
                name: "Artista",
                newName: "Artistas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artistas",
                table: "Artistas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Murales_Artistas_ArtistaId1",
                table: "Murales",
                column: "ArtistaId1",
                principalTable: "Artistas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Murales_Artistas_ArtistaId1",
                table: "Murales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artistas",
                table: "Artistas");

            migrationBuilder.RenameTable(
                name: "Artistas",
                newName: "Artista");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artista",
                table: "Artista",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Murales_Artista_ArtistaId1",
                table: "Murales",
                column: "ArtistaId1",
                principalTable: "Artista",
                principalColumn: "Id");
        }
    }
}
