using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;
using OrderSystem.Services;
using System.Diagnostics;

namespace OrderSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _service;

    public SuppliersController(ISupplierService service)
    {
        _service = service;
    }

    [HttpGet("Get All")]
    public async Task<IEnumerable<SupplierReadDto>> Get()
    {
        Debug.WriteLine($".\nSupplier Get All");
        return await _service.GetAllAsync();
    }

    [HttpPost("Create")]
    public async Task<ActionResult<SupplierReadDto>> Create(SupplierCreateDto dto)
    {
        Debug.WriteLine($".\nSupplier Create");
        return await _service.CreateAsync(dto);
    }

    [HttpGet("Read/{id}")]
    public async Task<ActionResult<SupplierReadDto>> GetSupplier(int id)
    {
        Debug.WriteLine($".\nSupplier Read {id}");
        var supplier = await _service.GetSupplier(id);
        return supplier == null ? NotFound() : supplier;
    }

    [HttpPut("Update{id}")]
    public async Task<IActionResult> Update(int id, Supplier supplier)
    {
        Debug.WriteLine($".\nSupplier Update {id}");
        var result = await _service.UpdateSupplier(id, supplier);
        return result == false ? BadRequest() : NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Debug.WriteLine($".\nSupplier Delete {id}");
        var result = await _service.DeleteSupplier(id);
        return result == false ? NotFound() : NoContent();
    }
}
