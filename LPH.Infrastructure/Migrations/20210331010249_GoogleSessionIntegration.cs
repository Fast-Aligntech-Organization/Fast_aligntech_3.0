using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LPH.Infrastructure.Migrations
{
    public partial class GoogleSessionIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GoogleUUID",
                table: "usuarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extencion",
                table: "files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeFile",
                table: "files",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleUUID",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Extencion",
                table: "files");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "files");

            migrationBuilder.DropColumn(
                name: "SizeFile",
                table: "files");
        }
    }
}
