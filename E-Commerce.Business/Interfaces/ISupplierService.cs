using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISupplierService : IAppUserService<SupplierCreateDto , SupplierListDto , SupplierUpdateDto , Supplier>
    {
        Task<List<SupplierListDto>> GetAllSupplierAsync();

        Task CreateSupplierAsync(SupplierCreateDto dto);

        Task RemoveSupplier(int supplierId);
    }
}
