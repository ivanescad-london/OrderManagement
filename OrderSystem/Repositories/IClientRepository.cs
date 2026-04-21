using OrderSystem.Models;

namespace OrderSystem.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> AddAsync(Client client);
        Task<Client?> GetByIdAsync(int id);
        Task<bool> Update(int id, Client client);
        Task<bool> Delete(int id);
    }
}
