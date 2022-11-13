using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LPH.Infrastructure.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EsVoluntario = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TipoUsuario = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Suscrito = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    GoogleUUID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Ancho = table.Column<double>(type: "double precision", nullable: false),
                    Alto = table.Column<double>(type: "double precision", nullable: false),
                    MaterialBarda = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Localizacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Tematica = table.Column<string>(type: "character varying(516)", maxLength: 516, nullable: true),
                    FechaRealizacionDeseada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Organizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordenes_usuarios_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdOrden = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Calificacion = table.Column<float>(type: "real", maxLength: 5, nullable: false),
                    Comentario = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comentarios_ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comentarios_usuarios_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdOrden = table.Column<int>(type: "integer", nullable: false),
                    UriString = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Extencion = table.Column<string>(type: "text", nullable: true),
                    SizeFile = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_files_ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
