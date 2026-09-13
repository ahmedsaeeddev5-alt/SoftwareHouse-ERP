using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _context;

        public ContractRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contract> AddAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();

            return contract;
        }

        public async Task DeleteAsync(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract != null)
            {
                _context.Contracts.Remove(contract);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contract>> GetAllAsync()
        {
            return await _context.Contracts
              .Include(c => c.Client)
              .Include(c => c.Project)
              .ToListAsync();
        }

        public async Task<Contract?> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.Project)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Contract contract)
        {
            _context.Contracts.Update(contract);
            await _context.SaveChangesAsync();
        }
    }
}
