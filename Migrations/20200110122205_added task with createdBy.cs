using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_2.Migrations
{
    public partial class addedtaskwithcreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Tasks",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "integer");
        }
    }
}
