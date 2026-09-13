using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AppDbContext _context;

    public AttendanceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attendance>> GetAllAsync()
    {
        return await _context.Attendances
            .Include(a => a.Employee)
            .ToListAsync();
    }

    public async Task<Attendance?> GetByIdAsync(int id)
    {
        return await _context.Attendances
            .Include(a => a.Employee)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Attendance> AddAsync(Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        await _context.SaveChangesAsync();

        return attendance;
    }

    public async Task UpdateAsync(Attendance attendance)
    {
        _context.Attendances.Update(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);

        if (attendance != null)
        {
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
        }
    }
}