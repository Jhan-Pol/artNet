using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class ArtistaActualizacionBibliografiainstaentreotros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bibliografia",
                table: "Artistas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disponibilidad",
                table: "Artistas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Artistas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bibliografia",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "Disponibilidad",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Artistas");
        }
    }
}
