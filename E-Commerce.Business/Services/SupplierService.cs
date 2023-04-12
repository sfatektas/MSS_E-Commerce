using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SupplierService : AppUserService<SupplierCreateDto, SupplierListDto, SupplierUpdateDto, Supplier>, ISupplierService
    {
        public SupplierService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public async Task CreateSupplierAsync(SupplierCreateDto dto)
        {
            var response = await base.GetByFilterAsync(x => x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber || x.PhoneNumber == dto.PhoneNumber);
            if (response.ResponseType == ResponseType.NotFound)
            {
                dto.UserTypeId = (int)AppUserType.Supplier;
                var response2 = await base.CreateAsync(dto);
            }
            else
                throw new SupplierBadRequestException();
        }

        public async Task<List<SupplierListDto>> GetAllSupplierAsync()
        {
            var response = await base.GetAllAsync();
            if (response.Data.Count == 0)
                throw new SupplierNotFoundException();
            return response.Data;
        }
    }
}
