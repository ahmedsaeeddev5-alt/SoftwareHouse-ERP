using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly AppDbContext _db;

        public ClientRepository(AppDbContext appDb)
        {
            _db = appDb;
        }
        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _db.Clients.FindAsync(id);

            if (client == null)
                return false;

            _db.Clients.Remove(client);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Client?> GetClientAsync(int id)
        {
            return await _db.Clients
                .Include(c => c.Projects)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await _db.Clients
                .Include(c => c.Projects)
                .ToListAsync();
        }

        public async Task<Client> InsertClientAsync(Client client)
        {
            await _db.Clients.AddAsync(client);
            await _db.SaveChangesAsync();

            return client;
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            _db.Clients.Update(client);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
