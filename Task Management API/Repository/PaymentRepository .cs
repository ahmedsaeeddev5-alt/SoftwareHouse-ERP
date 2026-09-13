using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _context.Payments
            .Include(p => p.Invoice)
            .ToListAsync();
    }

    public async Task<Payment?> GetByIdAsync(int id)
    {
        return await _context.Payments
            .Include(p => p.Invoice)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Payment> AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        return payment;
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment != null)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }
    }
}