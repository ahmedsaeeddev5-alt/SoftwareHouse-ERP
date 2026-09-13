using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsAsync();

        Task<Client?> GetClientAsync(int id);

        Task<Client> InsertClientAsync(Client client);

        Task<bool> UpdateClientAsync(Client client);

        Task<bool> DeleteClientAsync(int id);
    }
}
