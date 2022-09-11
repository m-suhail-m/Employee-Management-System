using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int ReportingLineManagerId { get; set; }
        public virtual Employee ReportingLineManager { get; set; }

       

        
    }
}
