using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Management_System_API.Migrations
{
    public partial class seed_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentDescription", "DepartmentName", "HeadOfDepartmentId" },
                values: new object[] { 1, "The department that deals with information and technology", "IT", 0 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "HasDepartment", "HasReportingLineManager", "PositionDescription", "PositionName" },
                values: new object[,]
                {
                    { 1, false, false, "The person responsible for managing the entire organisation", "CEO" },
                    { 2, false, false, "The person responsible for the day to day operation of the organisation", "COO" },
                    { 3, true, false, "The person in charge of a particular department", "Head of Department" },
                    { 4, true, false, "The person in charge of a particular group of employees within a department", "Reporting Line Manager" },
                    { 5, true, true, "A person who develops frontend applications", "Frontend Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 5);
        }
    }
}
