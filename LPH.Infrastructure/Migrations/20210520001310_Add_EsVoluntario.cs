using Microsoft.EntityFrameworkCore.Migrations;

namespace LPH.Infrastructure.Migrations
{
    public partial class Add_EsVoluntario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsVoluntario",
                table: "usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsVoluntario",
                table: "usuarios");
        }
    }
}
