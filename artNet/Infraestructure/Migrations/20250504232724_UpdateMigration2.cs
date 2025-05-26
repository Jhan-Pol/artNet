using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mural_Artista_ArtistaId",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Mural");

            migrationBuilder.AlterColumn<string>(
                name: "ArtistaId",
                table: "Mural",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistaId1",
                table: "Mural",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Mural",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Mural",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Mural",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Mural_ArtistaId1",
                table: "Mural",
                column: "ArtistaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Mural_Artista_ArtistaId1",
                table: "Mural",
                column: "ArtistaId1",
                principalTable: "Artista",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mural_AspNetUsers_ArtistaId",
                table: "Mural",
                column: "ArtistaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mural_Artista_ArtistaId1",
                table: "Mural");

            migrationBuilder.DropForeignKey(
                name: "FK_Mural_AspNetUsers_ArtistaId",
                table: "Mural");

            migrationBuilder.DropIndex(
                name: "IX_Mural_ArtistaId1",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "ArtistaId1",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Mural");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistaId",
                table: "Mural",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Mural",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Mural",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Mural",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Mural_Artista_ArtistaId",
                table: "Mural",
                column: "ArtistaId",
                principalTable: "Artista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
