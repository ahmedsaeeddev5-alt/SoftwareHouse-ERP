using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly AppDbContext _context;

    public ExpenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        return await _context.Expenses
            .Include(e => e.Project)
            .ToListAsync();
    }

    public async Task<Expense?> GetByIdAsync(int id)
    {
        return await _context.Expenses
            .Include(e => e.Project)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Expense> AddAsync(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();

        return expense;
    }

    public async Task UpdateAsync(Expense expense)
    {
        _context.Expenses.Update(expense);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense != null)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}