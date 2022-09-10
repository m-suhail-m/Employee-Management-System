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

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            IQueryable<Employee> employees = _appDbContext.Employees;
            return await employees.ToArrayAsync();
        }
        public async Task<Employee[]> SearchEmployeesByStringFieldsAsync(string query)
        {
            IQueryable<Employee> employees = _appDbContext.Employees.Where(x=> x.Name.Contains(query) || x.Surname.Contains(query) || x.Position.Contains(query));
            return await employees.ToArrayAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            IQueryable<Employee> employee = _appDbContext.Employees.Where(x => x.EmployeeId == id);
            return await employee.FirstOrDefaultAsync();
        }

        public string GenerateEmployeeNumber(int id, DateTime birthdate)
        {
            string idNumber = id.ToString() + birthdate.ToString();
            return idNumber;
        }
    }
}
