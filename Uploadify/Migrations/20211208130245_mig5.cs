using Microsoft.EntityFrameworkCore.Migrations;

namespace Uploadify.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataFiles",
                table: "Documents",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Documents",
                newName: "DataFiles");
        }
    }
}
