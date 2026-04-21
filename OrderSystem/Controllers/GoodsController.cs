using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;
using OrderSystem.Services;
using System.Diagnostics;

namespace OrderSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoodsController : ControllerBase
{
    private readonly IGoodsService _service;

    public GoodsController(IGoodsService service)
    {
        _service = service;
    }

    [HttpGet("Get All")]
    public async Task<IEnumerable<GoodsReadDto>> Get()
    {
        Debug.WriteLine($".\nGoods Get All");
        return await _service.GetAllAsync();
    }

    [HttpPost("Create")]
    public async Task<ActionResult<GoodsReadDto>> Create(GoodsCreateDto dto)
    {
        Debug.WriteLine($".\nGoods Create");
        return await _service.CreateAsync(dto);
    }

    [HttpGet("Read/{id}")]
    public async Task<ActionResult<GoodsReadDto>> GetGoods(int id)
    {
        Debug.WriteLine($".\nGoods Read {id}");
        var goods = await _service.GetGoods(id);
        return goods == null ? NotFound() : goods;
    }

    [HttpPut("Update{id}")]
    public async Task<IActionResult> Update(int id, Goods goods)
    {
        Debug.WriteLine($".\nGoods Update {id}");
        var result = await _service.UpdateGoods(id, goods);
        return result == false ? BadRequest() : NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Debug.WriteLine($".\nGoods Delete {id}");
        var result = await _service.DeleteGoods(id);
        return result == false ? NotFound() : NoContent();
    }
}
