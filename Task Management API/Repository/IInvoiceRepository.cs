using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task<Invoice> AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(int id);
    }
}
