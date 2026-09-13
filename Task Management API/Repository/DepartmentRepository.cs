using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _db;

        public DepartmentRepository(AppDbContext appDb)
        {
            _db = appDb;
        }
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _db.Departments.FindAsync(id);

            if (department == null)
                return false;

            _db.Departments.Remove(department);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Department?> GetDepartmentAsync(int id)
        {
            return await _db.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _db.Departments
               .Include(d => d.Employees)
               .ToListAsync();
        }

        public async Task<Department> InsertDepartmentAsync(Department department)
        {
            await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();

            return department;
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            _db.Departments.Update(department);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
