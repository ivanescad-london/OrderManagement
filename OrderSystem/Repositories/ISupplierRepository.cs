using OrderSystem.Models;

namespace OrderSystem.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> AddAsync(Supplier supplier);
        Task<Supplier?> GetByIdAsync(int id);
        Task<bool> Update(int id, Supplier supplier);
        Task<bool> Delete(int id);
    }
}
