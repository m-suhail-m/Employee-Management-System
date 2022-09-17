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

                for(int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].ReportingLineManagerId != null)
                    {
                        Employee manager = await _repository.GetReportingLineManager((int)employees[i].ReportingLineManagerId);
                        employees[i].ReportingLineManager = manager;
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
           
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetAllReportingLineManagers")]
        public async Task<IActionResult> GetAllReportingLineManagers()
        {
            Employee[] reportingLineManagers = await _repository.GetAllReportingLineManagersAsync();
            return Ok(reportingLineManagers);
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
                PositionId = employeeVM.PositionId
            };

            if (employeeVM.DepartmentId != 0)
            {
                newEmployee.DepartmentId = employeeVM.DepartmentId;
            }

            if (employeeVM.ReportingLineManagerId != 0)
            {
                newEmployee.ReportingLineManagerId = employeeVM.ReportingLineManagerId;
            }


            try
            {
                _repository.Add(newEmployee);
                await _repository.SaveAllChangesAsync();

                newEmployee.EmployeeNumber = _repository.GenerateEmployeeNumber(newEmployee.EmployeeId, newEmployee.BirthDate);
                await _repository.SaveAllChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
  
        }

        [HttpGet]
        [Route("SearchEmployeeById/{id}")]
        public async Task<IActionResult> SearchEmployeeById(int id)
        {
            Employee employee = await _repository.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("SearchEmployeesByQuery/{query}")]
        public async Task<IActionResult> SearchEmployeesByQuery(string query)
        {
            Employee[] employees = await _repository.SearchEmployeesByStringFieldsAsync(query);
            return Ok(employees);
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeVM employeeVM)
        {
            Employee currentEmployee = await _repository.GetEmployeeByIdAsync(id);
            if (currentEmployee == null) return NotFound();

            currentEmployee.Name = employeeVM.Name;
            currentEmployee.Surname = employeeVM.Surname;
            currentEmployee.BirthDate = employeeVM.BirthDate;
            currentEmployee.Salary = employeeVM.Salary;
            currentEmployee.PositionId = employeeVM.PositionId;

            if (employeeVM.DepartmentId != 0)
            {
                currentEmployee.DepartmentId = employeeVM.DepartmentId;
            }

            if (employeeVM.ReportingLineManagerId != 0)
            {
                currentEmployee.ReportingLineManagerId = employeeVM.ReportingLineManagerId;
            }

            try
            {
                if(! await _repository.SaveAllChangesAsync())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            return NoContent();
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employee = await _repository.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();

            try
            {
                _repository.Delete(employee);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            if(await _repository.SaveAllChangesAsync())
            {
                return NoContent();
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
