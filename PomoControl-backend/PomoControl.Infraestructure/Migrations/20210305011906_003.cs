using Microsoft.EntityFrameworkCore.Migrations;

namespace PomoControl.Infraestructure.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");
        }
    }
}
