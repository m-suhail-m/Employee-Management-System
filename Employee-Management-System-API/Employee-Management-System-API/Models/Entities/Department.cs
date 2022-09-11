using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public int HeadOfDepartmentId {get;set;}
        //public virtual Employee HeadOfDepartment { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
