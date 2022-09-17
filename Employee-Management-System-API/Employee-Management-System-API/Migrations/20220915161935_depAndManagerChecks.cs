using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Management_System_API.Migrations
{
    public partial class depAndManagerChecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasDepartment",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasReportingLineManager",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDepartment",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "HasReportingLineManager",
                table: "Positions");
        }
    }
}
