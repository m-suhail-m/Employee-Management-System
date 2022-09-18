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
            IQueryable<Employee> employees = _appDbContext.Employees.Include(x=>x.Department).Include(x=>x.Position);
            return await employees.ToArrayAsync();
        }
        public async Task<Employee[]> SearchEmployeesByStringFieldsAsync(string query)
        {
            IQueryable<Employee> employees = _appDbContext.Employees.Where(x=> x.Name.Contains(query) || x.Surname.Contains(query) || x.Department.DepartmentName.Contains(query) || x.Position.PositionName.Contains(query) || x.ReportingLineManager.Name.Contains(query) || x.EmployeeNumber.Contains(query)  ).Include(x => x.Department).Include(x => x.Position).Include(x=>x.ReportingLineManager);
            return await employees.ToArrayAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            IQueryable<Employee> employee = _appDbContext.Employees.Where(x => x.EmployeeId == id).Include(x => x.Department).Include(x => x.Position);
            return await employee.FirstOrDefaultAsync();
        }

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

            return  idNumber;
        }

        public async Task<Employee> GetReportingLineManager(int id)
        {
            IQueryable<Employee> manager = _appDbContext.Employees.Where(e => e.EmployeeId == id);
            return await manager.FirstOrDefaultAsync();
        }
        public async Task<Employee[]> GetAllReportingLineManagersAsync()
        {
            IQueryable<Employee> manager = _appDbContext.Employees.Where(e => e.Position.PositionName == "Reporting Line Manager");
            return await manager.ToArrayAsync();
        }

        //Position
        public async Task<Position[]> GetAllPositionsAsync()
        {
            IQueryable<Position> positions = _appDbContext.Positions;
            return await positions.ToArrayAsync();
        }
        public async Task<Position> GetPositionById(int id)
        {
            IQueryable<Position> positions = _appDbContext.Positions.Where(x=>x.PositionId ==id);
            return await positions.FirstOrDefaultAsync();
        }

        public async Task<Position[]> GetPositionByName(string query)
        {
            IQueryable<Position> positions = _appDbContext.Positions.Where(p => p.PositionName.Contains(query));
            return await positions.ToArrayAsync();
        }

        //Department
        public async Task<Department[]> GetAllDepartmentsAsync()
        {
            IQueryable<Department> departments = _appDbContext.Departments.Include(e=>e.Employees);
            return await departments.ToArrayAsync();
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            IQueryable<Department> department = _appDbContext.Departments.Where(x => x.DepartmentId == id);
            return await department.FirstOrDefaultAsync();
        }
        public async Task<Department[]> GetDepartmentByName(string query)
        {
            IQueryable<Department> departments = _appDbContext.Departments.Where(p => p.DepartmentName.Contains(query));
            return await departments.ToArrayAsync();
        }

    }
}
