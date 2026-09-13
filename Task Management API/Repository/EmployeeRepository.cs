using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext appDb)
        {
            _db = appDb;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _db.Employees.FindAsync(id);

            if (employee == null)
                return false;

            _db.Employees.Remove(employee);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await _db.Employees
                .Include(e => e.Department)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _db.Employees
                .Include(e => e.Department)
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _db.Employees.Update(employee);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
