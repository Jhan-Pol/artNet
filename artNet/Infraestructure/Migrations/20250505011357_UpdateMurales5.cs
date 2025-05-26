using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMurales5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Murales_Artistas_ArtistaId1",
                table: "Murales");

            migrationBuilder.DropForeignKey(
                name: "FK_Murales_AspNetUsers_ArtistaId",
                table: "Murales");

            migrationBuilder.DropIndex(
                name: "IX_Murales_ArtistaId1",
                table: "Murales");

            migrationBuilder.DropColumn(
                name: "ArtistaId1",
                table: "Murales");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistaId",
                table: "Murales",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Murales_Artistas_ArtistaId",
                table: "Murales",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Murales_Artistas_ArtistaId",
                table: "Murales");

            migrationBuilder.AlterColumn<string>(
                name: "ArtistaId",
                table: "Murales",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistaId1",
                table: "Murales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Murales_ArtistaId1",
                table: "Murales",
                column: "ArtistaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Murales_Artistas_ArtistaId1",
                table: "Murales",
                column: "ArtistaId1",
                principalTable: "Artistas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Murales_AspNetUsers_ArtistaId",
                table: "Murales",
                column: "ArtistaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
