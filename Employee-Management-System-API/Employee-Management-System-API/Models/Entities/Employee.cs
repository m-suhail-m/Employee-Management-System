using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.Entities
{
    public class Employee:Person
    {
        public int EmployeeId { get; set; }   
        public int ReportingLineManagerId { get; set; }
        public virtual ReportingLineManager ReportingLineManager { get; set; }
    }
}
