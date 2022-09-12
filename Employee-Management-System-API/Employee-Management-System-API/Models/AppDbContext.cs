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
           

            builder.Entity<Employee>()
                 .HasOne(d => d.Department)
                 .WithMany(e=> e.Employees)
                 .HasForeignKey(d=>d.DepartmentId)
                 .IsRequired(false);

            builder.Entity<Employee>()
                 .HasOne(p=>p.Position)
                 .WithMany()
                 .HasForeignKey(p=> p.PositionId);

            builder.Entity<Employee>()
                 .HasOne(l=> l.ReportingLineManager)
                 .WithOne()
                 .IsRequired(false);

            //builder.Entity<Department>()
            //    .HasOne("HeadOfDepartment")
            //    .WithOne("Department")
            //    .HasForeignKey("HeadOfDepartmentId");

            //builder.Entity<Department>()
            //    .HasMany(e => e.Employees)
            //    .WithOne()
            //    .IsRequired(false);

            builder.Entity<Position>()
                .HasMany(e=> e.Employees)
                .WithOne();


            base.OnModelCreating(builder);


        }
    }
}
