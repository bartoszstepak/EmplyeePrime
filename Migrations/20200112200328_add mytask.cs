using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_2.Migrations
{
    public partial class addmytask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.CreateTable(
                name: "MyTasks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(150)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    status = table.Column<string>(type: "varchar(255)", nullable: false),
                    createdBy = table.Column<string>(type: "integer", nullable: false),
                    assignedTo = table.Column<string>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTasks", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTasks");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assignedTo = table.Column<string>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy = table.Column<string>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                });
        }
    }
}
