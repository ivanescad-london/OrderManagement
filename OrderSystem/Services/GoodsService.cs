using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;
using OrderSystem.Repositories;
using System.Diagnostics;

namespace OrderSystem.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsRepository _repository;

        public GoodsService(IGoodsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GoodsReadDto>> GetAllAsync()
        {
            Debug.WriteLine($"Goods S: GetAllAsync ");
            var goods = await _repository.GetAllAsync();
         
            return goods.Select(c => new GoodsReadDto
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
            });
        }

        public async Task<GoodsReadDto> CreateAsync(GoodsCreateDto dto)
        {
            Debug.WriteLine($"Goods S: CreateAsync ");
            var goods = new Goods
            {
                Name = dto.Name
            };

            var created = await _repository.AddAsync(goods);

            return new GoodsReadDto
            {
                Id = created.Id,
                Name = goods.Name,
                Price = goods.Price,
            };
        }

        public async Task<ActionResult<GoodsReadDto>> GetGoods(int id)
        {
            Debug.WriteLine($"Goods S: GetGoods id={id}");
            var goods = await _repository.GetByIdAsync(id);
            return goods == null ? null : new GoodsReadDto
            {
                Id = goods.Id,
                Name = goods.Name,
                Price = goods.Price,
            };
        }

        public async Task<bool> UpdateGoods(int id, Goods goods)
        {
            Debug.WriteLine($"Goods S: UpdateGoods id={id} goods.id={goods.Id}");
            return await _repository.Update(id, goods);
        }

        public async Task<bool> DeleteGoods(int id)
        {
            Debug.WriteLine($"Goods S: DeleteGoods id={id}");
            return await _repository.Delete(id);
        }
    }
}
