using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;
using OrderSystem.Services;
using System.Diagnostics;

namespace OrderSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _service;

    public ClientsController(IClientService service)
    {
        _service = service;
    }

    [HttpGet("Get All")]
    public async Task<IEnumerable<ClientReadDto>> Get()
    {
        Debug.WriteLine($".\nClient Get All");
        return await _service.GetAllAsync();
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ClientReadDto>> Create(ClientCreateDto dto)
    {
        Debug.WriteLine($".\nClient Create");
        return await _service.CreateAsync(dto);
    }

    [HttpGet("Read/{id}")]
    public async Task<ActionResult<ClientReadDto>> GetClient(int id)
    {
        Debug.WriteLine($".\nClient Read {id}");
        var client = await _service.GetClient(id);
        return client == null ? NotFound() : client;
    }

    [HttpPut("Update{id}")]
    public async Task<IActionResult> Update(int id, Client client)
    {
        Debug.WriteLine($".\nClient Update {id}");
        var result = await _service.UpdateClient(id, client);
        return result == false ? BadRequest() : NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Debug.WriteLine($".\nClient Delete {id}");
        var result = await _service.DeleteClient(id);
        return result == false ? NotFound() : NoContent();
    }
}
