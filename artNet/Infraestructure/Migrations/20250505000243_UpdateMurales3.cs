using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artNet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMurales3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reaccion_Mural_MuralId",
                table: "Reaccion");

            migrationBuilder.DropTable(
                name: "Mural");

            migrationBuilder.CreateTable(
                name: "Murales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtistaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Murales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Murales_Artista_ArtistaId1",
                        column: x => x.ArtistaId1,
                        principalTable: "Artista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Murales_AspNetUsers_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Murales_ArtistaId",
                table: "Murales",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Murales_ArtistaId1",
                table: "Murales",
                column: "ArtistaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaccion_Murales_MuralId",
                table: "Reaccion",
                column: "MuralId",
                principalTable: "Murales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reaccion_Murales_MuralId",
                table: "Reaccion");

            migrationBuilder.DropTable(
                name: "Murales");

            migrationBuilder.CreateTable(
                name: "Mural",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtistaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtistaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mural", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mural_Artista_ArtistaId1",
                        column: x => x.ArtistaId1,
                        principalTable: "Artista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mural_AspNetUsers_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mural_ArtistaId",
                table: "Mural",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mural_ArtistaId1",
                table: "Mural",
                column: "ArtistaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaccion_Mural_MuralId",
                table: "Reaccion",
                column: "MuralId",
                principalTable: "Mural",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
