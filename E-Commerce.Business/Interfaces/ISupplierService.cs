using E_Commerce.Business.Services;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    internal interface ISupplierService : IAppUserService<SupplierCreateDto , SupplierListDto , SupplierUpdateDto , Supplier>
    {

    }
}
