using Employee_Management_System_API.Models;
using Employee_Management_System_API.Models.Entities;
using Employee_Management_System_API.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository _repository;

        public EmployeeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            Employee[] employees;
            try
            {
                 employees = await _repository.GetAllEmployeesAsync();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
           
            return Ok(employees);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeVM employeeVM)
        {

            var newEmployee = new Employee
            {
                Name = employeeVM.Name,
                Surname = employeeVM.Surname,
                BirthDate = employeeVM.BirthDate,
                Salary = employeeVM.Salary,
                PositionId = employeeVM.PositionId,
                DepartmentId = employeeVM.DepartmentId
                //EmployeeNumber = _repository.GenerateEmployeeNumber(employeeVM.EmployeeId, employeeVM.BirthDate)

            };


            try
            {
                _repository.Add(newEmployee);
                await _repository.SaveAllChangesAsync();

                newEmployee.EmployeeNumber = _repository.GenerateEmployeeNumber(newEmployee.EmployeeId, newEmployee.BirthDate);

                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
   
          

           
        }
    }
}
