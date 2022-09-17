using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.Entities
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string PositionDescription { get; set; }
        public bool HasReportingLineManager { get; set; }
        public bool HasDepartment { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
