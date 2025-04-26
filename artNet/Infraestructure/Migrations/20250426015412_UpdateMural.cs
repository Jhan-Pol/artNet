using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Mural",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Mural",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Mural");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Mural");
        }
    }
}
