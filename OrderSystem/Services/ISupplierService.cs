using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;

namespace OrderSystem.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierReadDto>> GetAllAsync();
        Task<SupplierReadDto> CreateAsync(SupplierCreateDto dto);
        Task<ActionResult<SupplierReadDto>> GetSupplier(int id);
        Task<bool> UpdateSupplier(int id, Supplier supplier);
        Task<bool> DeleteSupplier(int id);
    }
}
