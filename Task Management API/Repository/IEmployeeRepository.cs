using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task<Employee?> GetEmployeeAsync(int id);

        Task<Employee> InsertEmployeeAsync(Employee employee);

        Task<bool> UpdateEmployeeAsync(Employee employee);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}
