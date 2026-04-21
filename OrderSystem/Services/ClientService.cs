using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;
using OrderSystem.Repositories;
using System.Diagnostics;

namespace OrderSystem.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClientReadDto>> GetAllAsync()
        {
            Debug.WriteLine($"\nS: GetAllAsync ");
            var clients = await _repository.GetAllAsync();
         
            return clients.Select(c => new ClientReadDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<ClientReadDto> CreateAsync(ClientCreateDto dto)
        {
            Debug.WriteLine($"Client S: CreateAsync ");
            var client = new Client
            {
                Name = dto.Name
            };

            var created = await _repository.AddAsync(client);

            return new ClientReadDto
            {
                Id = created.Id,
                Name = created.Name
            };
        }

        public async Task<ActionResult<ClientReadDto>> GetClient(int id)
        {
            Debug.WriteLine($"\nS: GetClient id={id}");
            var client = await _repository.GetByIdAsync(id);
            return client == null ? null : new ClientReadDto
            {
                Id = client.Id,
                Name = client.Name
            };
        }

        public async Task<bool> UpdateClient(int id, Client client)
        {
            Debug.WriteLine($"\nS: UpdateClient id={id} client.id={client.Id}");
            return await _repository.Update(id, client);
        }
        
        public async Task<bool> DeleteClient(int id)
        {
            Debug.WriteLine($"\nS: DeleteClient id={id}");
            return await _repository.Delete(id);
        }
    }
}
