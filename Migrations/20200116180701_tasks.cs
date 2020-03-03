using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_2.Migrations
{
    public partial class tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "MyTasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "MyTasks",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
