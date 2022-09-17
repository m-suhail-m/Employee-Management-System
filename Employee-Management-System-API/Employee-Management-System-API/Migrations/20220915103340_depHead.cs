using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Management_System_API.Migrations
{
    public partial class depHead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeadOfDepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadOfDepartmentId",
                table: "Departments");
        }
    }
}
