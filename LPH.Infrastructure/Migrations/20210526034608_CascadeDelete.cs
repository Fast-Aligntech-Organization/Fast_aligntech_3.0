using Microsoft.EntityFrameworkCore.Migrations;

namespace LPH.Infrastructure.Migrations
{
    public partial class CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_ordenes_IdOrden",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_IdUser",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_files_ordenes_IdOrden",
                table: "files");

            migrationBuilder.DropForeignKey(
                name: "FK_ordenes_usuarios_IdUser",
                table: "ordenes");

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_ordenes_IdOrden",
                table: "comentarios",
                column: "IdOrden",
                principalTable: "ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_IdUser",
                table: "comentarios",
                column: "IdUser",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_files_ordenes_IdOrden",
                table: "files",
                column: "IdOrden",
                principalTable: "ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ordenes_usuarios_IdUser",
                table: "ordenes",
                column: "IdUser",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_ordenes_IdOrden",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_IdUser",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_files_ordenes_IdOrden",
                table: "files");

            migrationBuilder.DropForeignKey(
                name: "FK_ordenes_usuarios_IdUser",
                table: "ordenes");

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_ordenes_IdOrden",
                table: "comentarios",
                column: "IdOrden",
                principalTable: "ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_IdUser",
                table: "comentarios",
                column: "IdUser",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_files_ordenes_IdOrden",
                table: "files",
                column: "IdOrden",
                principalTable: "ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ordenes_usuarios_IdUser",
                table: "ordenes",
                column: "IdUser",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
