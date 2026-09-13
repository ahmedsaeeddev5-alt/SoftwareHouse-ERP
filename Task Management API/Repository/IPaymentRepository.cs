using Task_Management_API.Data.Models;

namespace Task_Management_API.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllAsync();
    Task<Payment?> GetByIdAsync(int id);
    Task<Payment> AddAsync(Payment payment);
    Task UpdateAsync(Payment payment);
    Task DeleteAsync(int id);
}