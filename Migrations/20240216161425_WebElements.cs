using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selenium_Wizard.Migrations
{
    public partial class WebElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCode = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    controlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selectorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    methodToExecute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceColumn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebElements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebElements");
        }
    }
}
