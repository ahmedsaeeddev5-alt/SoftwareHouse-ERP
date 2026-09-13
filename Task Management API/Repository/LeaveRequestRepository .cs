using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.Repositories;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly AppDbContext _context;

    public LeaveRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
    {
        return await _context.LeaveRequests
            .Include(l => l.Employee)
            .ToListAsync();
    }

    public async Task<LeaveRequest?> GetByIdAsync(int id)
    {
        return await _context.LeaveRequests
            .Include(l => l.Employee)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest)
    {
        await _context.LeaveRequests.AddAsync(leaveRequest);
        await _context.SaveChangesAsync();

        return leaveRequest;
    }

    public async Task UpdateAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Update(leaveRequest);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var leaveRequest = await _context.LeaveRequests.FindAsync(id);

        if (leaveRequest != null)
        {
            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();
        }
    }
}