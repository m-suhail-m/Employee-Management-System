using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Management_System_API.Migrations
{
    public partial class empdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentDescription", "DepartmentName", "HeadOfDepartmentId" },
                values: new object[,]
                {
                    { 2, "The department that deals with employees and payroll", "HR", 0 },
                    { 3, "The department that deals with finances", "Accounting", 0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "DepartmentId", "EmployeeNumber", "Name", "PositionId", "ReportingLineManagerId", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 9, 17, 10, 38, 37, 604, DateTimeKind.Local).AddTicks(427), null, "0001198801", "Bob", 1, null, 50000.0, "Gates" },
                    { 2, new DateTime(1992, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4237), null, "0002199801", "Harriet", 2, null, 20000.0, "Crane" },
                    { 3, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4269), null, "0003200001", "Jonathan", 2, null, 20000.0, "Nate" },
                    { 4, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4284), 1, "0004200005", "Bill", 3, null, 15000.0, "Shane" },
                    { 7, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4522), 1, "0007200002", "Matt", 4, null, 10000.0, "Flake" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "HasDepartment", "HasReportingLineManager", "PositionDescription", "PositionName" },
                values: new object[,]
                {
                    { 6, true, true, "A person who deals with employees", "HR Officer" },
                    { 7, true, true, "A person who crunches numbers", "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "DepartmentId", "EmployeeNumber", "Name", "PositionId", "ReportingLineManagerId", "Salary", "Surname" },
                values: new object[,]
                {
                    { 5, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4493), 2, "0005200005", "Charel", 3, null, 15000.0, "Heinz" },
                    { 8, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4534), 2, "0008200002", "Blake", 4, null, 10000.0, "Flake" },
                    { 6, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4510), 3, "0006200005", "Calvin", 3, null, 15000.0, "Kane" },
                    { 9, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4546), 3, "0009200003", "Candice", 4, null, 10000.0, "Catnipp" },
                    { 10, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4559), 1, "0010200003", "Ben", 5, 7, 8000.0, "Brown" },
                    { 11, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4737), 1, "0011200003", "Percival", 5, 7, 8000.0, "Purple" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "DepartmentId", "EmployeeNumber", "Name", "PositionId", "ReportingLineManagerId", "Salary", "Surname" },
                values: new object[,]
                {
                    { 12, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4750), 2, "0012200003", "Yvonne", 6, 8, 8000.0, "Yellow" },
                    { 13, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4762), 2, "0013200003", "Greg", 6, 8, 8000.0, "Green" },
                    { 14, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4774), 3, "0014200003", "Veronica", 7, 9, 8000.0, "Vermillion" },
                    { 15, new DateTime(1994, 9, 17, 10, 38, 37, 605, DateTimeKind.Local).AddTicks(4785), 3, "0015200003", "Philip", 7, 9, 8000.0, "Fuschia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);
        }
    }
}
