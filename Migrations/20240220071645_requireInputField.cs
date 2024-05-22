using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selenium_Wizard.Migrations
{
    public partial class requireInputField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "requiresInput",
                table: "WebElements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requiresInput",
                table: "WebElements");
        }
    }
}
