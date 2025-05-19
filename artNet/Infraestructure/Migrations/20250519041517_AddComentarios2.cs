using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class AddComentarios2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_User_UsernameId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsernameId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsernameId",
                table: "Comentarios");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_User_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_User_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.AddColumn<int>(
                name: "UsernameId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsernameId",
                table: "Comentarios",
                column: "UsernameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_User_UsernameId",
                table: "Comentarios",
                column: "UsernameId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
