using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomoControl.DAL.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scope",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(75)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Steps = table.Column<int>(type: "int", nullable: false),
                    WorkSeconds = table.Column<int>(type: "int", nullable: false),
                    IntervalSeconds = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCode = table.Column<int>(type: "int", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scope", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ScopeItems",
                columns: table => new
                {
                    ScopeItemCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeCode = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<byte>(type: "BYTE", nullable: false),
                    Commentary = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScopeItems", x => x.ScopeItemCode);
                    table.ForeignKey(
                        name: "FK_ScopeItems_Scope_ScopeCode",
                        column: x => x.ScopeCode,
                        principalTable: "Scope",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScopeItems_ScopeCode",
                table: "ScopeItems",
                column: "ScopeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScopeItems");

            migrationBuilder.DropTable(
                name: "Scope");
        }
    }
}
