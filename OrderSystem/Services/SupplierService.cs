using Microsoft.AspNetCore.Mvc;
using OrderSystem.DTOs;
using OrderSystem.Models;
using OrderSystem.Repositories;
using System.Diagnostics;

namespace OrderSystem.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SupplierReadDto>> GetAllAsync()
        {
            Debug.WriteLine($"Supplier S: GetAllAsync ");
            var suppliers = await _repository.GetAllAsync();
         
            return suppliers.Select(c => new SupplierReadDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<SupplierReadDto> CreateAsync(SupplierCreateDto dto)
        {
            Debug.WriteLine($"Supplier S: CreateAsync ");
            var supplier = new Supplier
            {
                Name = dto.Name
            };

            var created = await _repository.AddAsync(supplier);

            return new SupplierReadDto
            {
                Id = created.Id,
                Name = created.Name
            };
        }

        public async Task<ActionResult<SupplierReadDto>> GetSupplier(int id)
        {
            Debug.WriteLine($"Supplier S: GetSupplier id={id}");
            var supplier = await _repository.GetByIdAsync(id);
            return supplier == null ? null : new SupplierReadDto
            {
                Id = supplier.Id,
                Name = supplier.Name
            };
        }

        public async Task<bool> UpdateSupplier(int id, Supplier supplier)
        {
            Debug.WriteLine($"Supplier S: UpdateSupplier id={id} supplier.id={supplier.Id}");
            return await _repository.Update(id, supplier);
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            Debug.WriteLine($"Supplier S: DeleteSupplier id={id}");
            return await _repository.Delete(id);
        }
    }
}
