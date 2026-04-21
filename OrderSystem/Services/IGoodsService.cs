using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;

namespace OrderSystem.Services
{
    public interface IGoodsService
    {
        Task<IEnumerable<GoodsReadDto>> GetAllAsync();
        Task<GoodsReadDto> CreateAsync(GoodsCreateDto dto);
        Task<ActionResult<GoodsReadDto>> GetGoods(int id);
        Task<bool> UpdateGoods(int id, Goods supplier);
        Task<bool> DeleteGoods(int id);
    }
}
