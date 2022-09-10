using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.Entities
{
    public class ReportingLineManager:Employee
    {
        public new int ReportingLineManagerId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
