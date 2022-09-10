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
                Position = employeeVM.Position
                //EmployeeNumber = _repository.GenerateEmployeeNumber(employeeVM.EmployeeId, employeeVM.BirthDate)
                
            };

            if (employeeVM.ReportingLineManagerId != 0)
            {
                newEmployee.ReportingLineManagerId = employeeVM.ReportingLineManagerId;
                _repository.Add(newEmployee);
                newEmployee.EmployeeNumber = _repository.GenerateEmployeeNumber(newEmployee.EmployeeId, newEmployee.BirthDate);
            }

            else
            {
                Employee reportingLineManager = new ReportingLineManager();
                reportingLineManager = newEmployee;
                _repository.Add(reportingLineManager);
                reportingLineManager.EmployeeNumber = _repository.GenerateEmployeeNumber(newEmployee.EmployeeId, newEmployee.BirthDate);

            }

            try
            {
                await _repository.SaveAllChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
   
          

           
        }
    }
}
