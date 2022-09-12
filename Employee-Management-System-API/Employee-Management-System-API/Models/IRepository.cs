using Employee_Management_System_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Models
{
    public interface IRepository
    {
        //Common functions
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAllChangesAsync();

        //Employee
        Task<Employee[]> GetAllEmployeesAsync();
        Task<Employee[]> SearchEmployeesByStringFieldsAsync(string query);
        Task<Employee> GetEmployeeByIdAsync(int id);
        string GenerateEmployeeNumber(int id, DateTime birthdate);

        //Position
        Task<Position[]> GetAllPositionsAsync();

        //Department
        Task<Department[]> GetAllDepartmentsAsync();
    }
}
