using Employee_Management_System_API.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
                 .HasOne(d => d.Department)
                 .WithMany(e=> e.Employees)
                 .HasForeignKey(d=>d.DepartmentId)
                 .IsRequired(false);

            builder.Entity<Employee>()
                 .HasOne(p=>p.Position)
                 .WithMany(e=>e.Employees)
                 .HasForeignKey(p=> p.PositionId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                 .HasOne(l=> l.ReportingLineManager)
                 .WithMany()
                 .HasForeignKey(e=>e.ReportingLineManagerId)
                 .IsRequired(false);

       
            builder.Entity<Position>().HasData(
               new Position
               {
                  PositionId = 1,
                  PositionName= "CEO",
                  PositionDescription = "The person responsible for managing the entire organisation",
                  HasDepartment = false,
                  HasReportingLineManager = false
               });


            builder.Entity<Position>().HasData(
               new Position
               {
                   PositionId = 2,
                   PositionName = "COO",
                   PositionDescription = "The person responsible for the day to day operation of the organisation",
                   HasDepartment = false,
                   HasReportingLineManager = false
               });

            builder.Entity<Position>().HasData(
              new Position
              {
                  PositionId = 3,
                  PositionName = "Head of Department",
                  PositionDescription = "The person in charge of a particular department",
                  HasDepartment = true,
                  HasReportingLineManager = false
              });

            builder.Entity<Position>().HasData(
              new Position
              {
                  PositionId = 4,
                  PositionName = "Reporting Line Manager",
                  PositionDescription = "The person in charge of a particular group of employees within a department",
                  HasDepartment = true,
                  HasReportingLineManager = false
              });

            builder.Entity<Position>().HasData(
             new Position
             {
                 PositionId = 5,
                 PositionName = "Frontend Developer",
                 PositionDescription = "A person who develops frontend applications",
                 HasDepartment = true,
                 HasReportingLineManager = true
             });

            builder.Entity<Position>().HasData(
             new Position
             {
                 PositionId = 6,
                 PositionName = "HR Officer",
                 PositionDescription = "A person who deals with employees",
                 HasDepartment = true,
                 HasReportingLineManager = true
             });

            builder.Entity<Position>().HasData(
             new Position
             {
                 PositionId = 7,
                 PositionName = "Accountant",
                 PositionDescription = "A person who crunches numbers",
                 HasDepartment = true,
                 HasReportingLineManager = true
             });

            builder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "IT",
                    DepartmentDescription = "The department that deals with information and technology"
                    

                });

            builder.Entity<Department>().HasData(
               new Department
               {
                   DepartmentId = 2,
                   DepartmentName = "HR",
                   DepartmentDescription = "The department that deals with employees and payroll"


               });

            builder.Entity<Department>().HasData(
               new Department
               {
                   DepartmentId = 3,
                   DepartmentName = "Accounting",
                   DepartmentDescription = "The department that deals with finances"


               });

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    Name = "Bob",
                    Surname = "Gates",
                    BirthDate = DateTime.Now.AddYears(-40),
                    Salary = 50000,
                    PositionId = 1,
                    EmployeeNumber = "0001198801"
                });

            builder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 2,
                   Name = "Harriet",
                   Surname = "Crane",
                   BirthDate = DateTime.Now.AddYears(-30),
                   Salary = 20000,
                   PositionId = 2,
                   EmployeeNumber = "0002199801"
               });


            builder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 3,
                   Name = "Jonathan",
                   Surname = "Nate",
                   BirthDate = DateTime.Now.AddYears(-28),
                   Salary = 20000,
                   PositionId = 2,
                   EmployeeNumber = "0003200001"
               });

            builder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 4,
                   Name = "Bill",
                   Surname = "Shane",
                   BirthDate = DateTime.Now.AddYears(-28),
                   Salary = 15000,
                   PositionId = 3,
                   DepartmentId = 1,
                   EmployeeNumber = "0004200005"
               });

            builder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 5,
                   Name = "Charel",
                   Surname = "Heinz",
                   BirthDate = DateTime.Now.AddYears(-28),
                   Salary = 15000,
                   PositionId = 3,
                   DepartmentId = 2,
                   EmployeeNumber = "0005200005"
               });

            builder.Entity<Employee>().HasData(
              new Employee
              {
                  EmployeeId = 6,
                  Name = "Calvin",
                  Surname = "Kane",
                  BirthDate = DateTime.Now.AddYears(-28),
                  Salary = 15000,
                  PositionId = 3,
                  DepartmentId = 3,
                  EmployeeNumber = "0006200005"
              });

            builder.Entity<Employee>().HasData(
             new Employee
             {
                 EmployeeId = 7,
                 Name = "Matt",
                 Surname = "Flake",
                 BirthDate = DateTime.Now.AddYears(-28),
                 Salary = 10000,
                 PositionId = 4,
                 DepartmentId = 1,
                 EmployeeNumber = "0007200002"
             });

            builder.Entity<Employee>().HasData(
             new Employee
             {
                 EmployeeId = 8,
                 Name = "Blake",
                 Surname = "Flake",
                 BirthDate = DateTime.Now.AddYears(-28),
                 Salary = 10000,
                 PositionId = 4,
                 DepartmentId = 2,
                 EmployeeNumber = "0008200002"
             });

            builder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 9,
                Name = "Candice",
                Surname = "Catnipp",
                BirthDate = DateTime.Now.AddYears(-28),
                Salary = 10000,
                PositionId = 4,
                DepartmentId = 3,
                EmployeeNumber = "0009200003"
            });

           builder.Entity<Employee>().HasData(
           new Employee
           {
               EmployeeId = 10,
               Name = "Ben",
               Surname = "Brown",
               BirthDate = DateTime.Now.AddYears(-28),
               Salary = 8000,
               PositionId = 5,
               DepartmentId = 1,
               ReportingLineManagerId = 7,
               EmployeeNumber = "0010200003"
           });

          builder.Entity<Employee>().HasData(
          new Employee
          {
              EmployeeId = 11,
              Name = "Percival",
              Surname = "Purple",
              BirthDate = DateTime.Now.AddYears(-28),
              Salary = 8000,
              PositionId = 5,
              DepartmentId = 1,
              ReportingLineManagerId = 7,
              EmployeeNumber = "0011200003"
          });

            builder.Entity<Employee>().HasData(
             new Employee
             {
                 EmployeeId = 12,
                 Name = "Yvonne",
                 Surname = "Yellow",
                 BirthDate = DateTime.Now.AddYears(-28),
                 Salary = 8000,
                 PositionId = 6,
                 DepartmentId = 2,
                 ReportingLineManagerId = 8,
                 EmployeeNumber = "0012200003"
             });

            builder.Entity<Employee>().HasData(
             new Employee
             {
                 EmployeeId = 13,
                 Name = "Greg",
                 Surname = "Green",
                 BirthDate = DateTime.Now.AddYears(-28),
                 Salary = 8000,
                 PositionId = 6,
                 DepartmentId = 2,
                 ReportingLineManagerId = 8,
                 EmployeeNumber = "0013200003"
             });

            builder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 14,
                Name = "Veronica",
                Surname = "Vermillion",
                BirthDate = DateTime.Now.AddYears(-28),
                Salary = 8000,
                PositionId = 7,
                DepartmentId = 3,
                ReportingLineManagerId = 9,
                EmployeeNumber = "0014200003"
            });

            builder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 15,
                Name = "Philip",
                Surname = "Fuschia",
                BirthDate = DateTime.Now.AddYears(-28),
                Salary = 8000,
                PositionId = 7,
                DepartmentId = 3,
                ReportingLineManagerId = 9,
                EmployeeNumber = "0015200003"
            });

        }
    }
}
