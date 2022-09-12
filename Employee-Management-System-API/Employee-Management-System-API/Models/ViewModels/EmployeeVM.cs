using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.ViewModels
{
    public class EmployeeVM
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public int ReportingLineManagerId { get; set; }
    }
}
