using Employee_Management_System_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models
{
    public class Repository:IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //common functions
        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }
        public async Task<bool> SaveAllChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }


        //Employee
        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            IQueryable<Employee> employees = _appDbContext.Employees.Include(x=>x.Department.DepartmentId).Include(x=>x.Department.DepartmentName).Include(x=>x.Position.PositionId).Include(x=>x.Position.PositionName);
            return await employees.ToArrayAsync();
        }
        public async Task<Employee[]> SearchEmployeesByStringFieldsAsync(string query)
        {
            IQueryable<Employee> employees = _appDbContext.Employees.Where(x=> x.Name.Contains(query) || x.Surname.Contains(query)).Include(x => x.Department.DepartmentId).Include(x => x.Department.DepartmentName).Include(x => x.Position.PositionId).Include(x => x.Position.PositionName);
            return await employees.ToArrayAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            IQueryable<Employee> employee = _appDbContext.Employees.Where(x => x.EmployeeId == id).Include(x => x.Department.DepartmentId).Include(x => x.Department.DepartmentName).Include(x => x.Position.PositionId).Include(x => x.Position.PositionName);
            return await employee.FirstOrDefaultAsync();
        }


        //Department

        //Position
        public string GenerateEmployeeNumber(int id, DateTime birthdate)
        {
            string monthComponent ="";
            string idComponent = "";
            string yearComponent = birthdate.Year.ToString();
            if (birthdate.Month< 10)
            {
                monthComponent = "0" + birthdate.Month.ToString();
            }

            if(id < 10)
            {
                idComponent = "000" + id;
            }
            else if(id < 100)
            {
                idComponent = "00" + id;
            }
            else if(id < 1000)
            {
                idComponent = "0" + id;
            }
            string idNumber = idComponent + yearComponent + monthComponent;

            return idNumber;
        }
    }
}
