using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_2.Migrations
{
    public partial class AddedassigetTofortasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "assignedTo",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "assignedTo",
                table: "Tasks");
        }
    }
}
