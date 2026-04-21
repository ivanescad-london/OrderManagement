using OrderSystem.Models;

namespace OrderSystem.Repositories
{
    public interface IGoodsRepository
    {
        Task<List<Goods>> GetAllAsync();
        Task<Goods> AddAsync(Goods goods);
        Task<Goods?> GetByIdAsync(int id);
        Task<bool> Update(int id, Goods goods);
        Task<bool> Delete(int id);
    }
}
