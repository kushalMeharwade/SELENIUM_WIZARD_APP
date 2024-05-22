using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selenium_Wizard.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automation_Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeCode = table.Column<int>(type: "int", nullable: false),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automation_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Automation_Types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automation_Types", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automation_Names");

            migrationBuilder.DropTable(
                name: "Automation_Types");
        }
    }
}
