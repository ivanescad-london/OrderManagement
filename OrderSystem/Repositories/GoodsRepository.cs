using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;
using System.Diagnostics;

namespace OrderSystem.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly AppDbContext _context;

        public GoodsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Goods>> GetAllAsync()
        {
            Debug.WriteLine($"Goods R: Get All Goods Goods={_context.Goods.Count()}");
            return await _context.Goods.ToListAsync();
        }

        public async Task<Goods> AddAsync(Goods goods)
        {
            Debug.WriteLine($"Goods R: AddAsync Goods={_context.Goods.Count()}");
            _context.Goods.Add(goods);
            await _context.SaveChangesAsync();
            return goods;
        }

        public async Task<Goods?> GetByIdAsync(int id)
        {
            Debug.WriteLine($"Goods R: Get By Id id={id} Goods={_context.Goods.Count()}");
            var goods = await _context.Goods.FindAsync(id);
            return goods;
        }

        public async Task<bool> Update(int id, Goods goods)
        {
            Debug.WriteLine($"Goods R: Update id={id}  Goods={_context.Goods.Count()}");
            if (id != goods.Id) return false;

            _context.Entry(goods).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Debug.WriteLine($"Goods R: Delete id={id} Goods={_context.Goods.Count()}");
            var goods = await _context.Goods.FindAsync(id);
            if (goods == null)
            {
                Debug.WriteLine($"Goods R: Delete id={id} Goods={_context.Goods.Count()} return false");
                return false;
            }

            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();

            Debug.WriteLine($"Goods R: Delete id={id} Goods={_context.Goods.Count()} return true");
            return true;
        }
    }
}
