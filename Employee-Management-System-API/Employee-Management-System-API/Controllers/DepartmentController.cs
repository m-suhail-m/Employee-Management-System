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
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository _repository;

        public DepartmentController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                Department[] departments = await _repository.GetAllDepartmentsAsync();
                return Ok(departments);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentVM departmentVM)
        {
            Department department = new Department
            {
              DepartmentName = departmentVM.DepartmentName,
              DepartmentDescription = departmentVM.DepartmentDescription
              //HeadOfDepartmentId = departmentVM.HeadOfDepartmentId
            };

            //if(departmentVM.HeadOfDepartmentId != 0)
            //{
            //    department.HeadOfDepartmentId = departmentVM.HeadOfDepartmentId;
            //}

            try
            {
                _repository.Add(department);
                if (await _repository.SaveAllChangesAsync())
                {
                    return NoContent();
                }

                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("SearchDepartmentById/{id}")]
        public async Task<IActionResult> SearchDepartmentById(int id)
        {
            Department department = await _repository.GetDepartmentById(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpGet("SearchDepartmentsByQuery/{query}")]
        public async Task<IActionResult> SearchDepartmentsByQuery(string query)
        {
            Department[] departments = await _repository.GetDepartmentByName(query);
            return Ok(departments);
        }

        [HttpPut]
        [Route("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentVM departmentVM)
        {
            Department currentDepartment = await _repository.GetDepartmentById(id);
            if (currentDepartment == null) return NotFound();

            currentDepartment.DepartmentName = departmentVM.DepartmentName;
            currentDepartment.DepartmentDescription = departmentVM.DepartmentDescription;

            try
            {
                if (!await _repository.SaveAllChangesAsync())
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


        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            Department department = await _repository.GetDepartmentById(id);
            if (department == null) return NotFound();

            try
            {
                _repository.Delete(department);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            if (await _repository.SaveAllChangesAsync())
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
