using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();

        Task<LeaveRequest?> GetByIdAsync(int id);

        Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest);

        Task UpdateAsync(LeaveRequest leaveRequest);

        Task DeleteAsync(int id);
    }
}
