using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _context.Invoices
            .Include(i => i.Contract)
            .ToListAsync();
    }

    public async Task<Invoice?> GetByIdAsync(int id)
    {
        return await _context.Invoices
            .Include(i => i.Contract)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Invoice> AddAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();

        return invoice;
    }

    public async Task UpdateAsync(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);

        if (invoice != null)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}