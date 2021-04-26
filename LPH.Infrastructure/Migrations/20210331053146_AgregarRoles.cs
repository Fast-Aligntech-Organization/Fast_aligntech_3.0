using Microsoft.EntityFrameworkCore.Migrations;

namespace LPH.Infrastructure.Migrations
{
    public partial class AgregarRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "usuarios");
        }
    }
}
