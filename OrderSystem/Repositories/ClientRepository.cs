using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;
using System.Diagnostics;

namespace OrderSystem.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            Debug.WriteLine($"Client R: Get All Clients Clients={_context.Clients.Count()}");
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> AddAsync(Client client)
        {
            Debug.WriteLine($"Client R: AddAsync Clients={_context.Clients.Count()}");
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            Debug.WriteLine($"Client R: Get By Id Clients={_context.Clients.Count()}");
            var client = await _context.Clients.FindAsync(id);
            return client;
        }

        public async Task<bool> Update(int id, Client client)
        {
            Debug.WriteLine($"Client R: Update Clients={_context.Clients.Count()}");
            if (id != client.Id) return false;

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Debug.WriteLine($"Client R: Delete id={id} Clients={_context.Clients.Count()}");
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                Debug.WriteLine($"Client R: Delete id={id} Clients={_context.Clients.Count()} return false");
                return false;
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            Debug.WriteLine($"Client R: Delete id={id} Clients={_context.Clients.Count()} return true");
            return true;
        }
    }
}
