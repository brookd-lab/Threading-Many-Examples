using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickApi.Data;
using QuickApi.Models;

namespace QuickApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            return employee;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            Employee? foundEmployee = await GetEmployeeById(employee.Id);

            foundEmployee.Name = employee.Name;
            foundEmployee.Salary = employee.Salary;
            _context.Update(foundEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            Employee? foundEmployee = await GetEmployeeById(id);
            _context.Employee.Remove(foundEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
