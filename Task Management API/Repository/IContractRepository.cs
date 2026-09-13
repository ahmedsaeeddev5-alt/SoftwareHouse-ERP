using Task_Management_API.Data.Models;
namespace Task_Management_API.Repository
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetAllAsync();
        Task<Contract?> GetByIdAsync(int id);
        Task<Contract> AddAsync(Contract contract);
        Task UpdateAsync(Contract contract);
        Task DeleteAsync(int id);
    }
}
