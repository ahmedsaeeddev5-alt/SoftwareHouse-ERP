using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(int id);
        Task<Expense> AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(int id);
    }
}
