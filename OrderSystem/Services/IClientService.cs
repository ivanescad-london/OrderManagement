using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;

namespace OrderSystem.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientReadDto>> GetAllAsync();
        Task<ClientReadDto> CreateAsync(ClientCreateDto dto);
        Task<ActionResult<ClientReadDto>> GetClient(int id);
        Task<bool> UpdateClient(int id, Client client);
        Task<bool> DeleteClient(int id);     
    }
}
