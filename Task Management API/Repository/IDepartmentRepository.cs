using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentsAsync();

        Task<Department?> GetDepartmentAsync(int id);

        Task<Department> InsertDepartmentAsync(Department department);

        Task<bool> UpdateDepartmentAsync(Department department);

        Task<bool> DeleteDepartmentAsync(int id);
    }
}
