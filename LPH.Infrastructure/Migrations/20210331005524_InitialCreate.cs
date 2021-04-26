using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LPH.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Suscrito = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Ancho = table.Column<double>(type: "float", nullable: false),
                    Alto = table.Column<double>(type: "float", nullable: false),
                    MaterialBarda = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Localizacion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Tematica = table.Column<string>(type: "nvarchar(516)", maxLength: 516, nullable: true),
                    FechaRealizacionDeseada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Organizacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordenes_usuarios_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<float>(type: "real", maxLength: 5, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comentarios_ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comentarios_usuarios_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    UriString = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_files_ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_Id",
                table: "comentarios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_IdOrden",
                table: "comentarios",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_IdUser",
                table: "comentarios",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_files_IdOrden",
                table: "files",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_Id",
                table: "ordenes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_IdUser",
                table: "ordenes",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Email",
                table: "usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Id",
                table: "usuarios",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "ordenes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
