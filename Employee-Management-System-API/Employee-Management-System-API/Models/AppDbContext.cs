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
        public DbSet<ReportingLineManager> ReportingLineManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
                .HasBaseType<Person>()
                .HasOne("ReportingLineManager")
                .WithMany("Employees")
                .HasForeignKey("ReportingLineManagerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ReportingLineManager>()
                .HasBaseType<Person>()
                .HasMany("Employees")
                .WithOne("ReportingLineManager")
                .OnDelete(DeleteBehavior.Restrict);
                
           
        }
    }
}
