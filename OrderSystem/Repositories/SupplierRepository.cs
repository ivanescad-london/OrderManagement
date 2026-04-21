using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;
using System.Diagnostics;

namespace OrderSystem.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            Debug.WriteLine($"Supplier R: Get All Suppliers Suppliers={_context.Suppliers.Count()}");
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> AddAsync(Supplier supplier)
        {
            Debug.WriteLine($"Supplier R: AddAsync Suppliers={_context.Suppliers.Count()}");
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            Debug.WriteLine($"Supplier R: Get By Id id={id} Suppliers={_context.Suppliers.Count()}");
            var supplier = await _context.Suppliers.FindAsync(id);
            return supplier;
        }

        public async Task<bool> Update(int id, Supplier supplier)
        {
            Debug.WriteLine($"Supplier R: Update id={id} Suppliers={_context.Suppliers.Count()}");
            if (id != supplier.Id) return false;

            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Debug.WriteLine($"Supplier R: Delete id={id} Suppliers={_context.Suppliers.Count()}");
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                Debug.WriteLine($"Supplier R: Delete id={id} Suppliers={_context.Suppliers.Count()} return false");
                return false;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            Debug.WriteLine($"Supplier R: Delete id={id} Suppliers={_context.Suppliers.Count()} return true");
            return true;
        }
    }
}
