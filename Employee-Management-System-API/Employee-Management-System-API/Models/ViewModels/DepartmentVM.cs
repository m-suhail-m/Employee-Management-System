using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models.ViewModels
{
    public class DepartmentVM
    {
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public int HeadOfDepartmentId { get; set; }
    }
}
