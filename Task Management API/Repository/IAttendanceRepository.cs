using Task_Management_API.Data.Models;

namespace Task_Management_API.Repositories;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAllAsync();
    Task<Attendance?> GetByIdAsync(int id);
    Task<Attendance> AddAsync(Attendance attendance);
    Task UpdateAsync(Attendance attendance);
    Task DeleteAsync(int id);
}