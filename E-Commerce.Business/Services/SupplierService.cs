using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Common.Consts;
using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SupplierService : AppUserService<SupplierCreateDto, SupplierListDto, SupplierUpdateDto, Supplier>, ISupplierService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        readonly IStorage _storage;
        public SupplierService(IUow uow, IMapper mapper, UserManager<AppUser> userManager, IStorage storage) : base(uow, mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _storage = storage;
        }

        public async Task CreateSupplierAsync(SupplierCreateDto dto)
        {
            var response = await base.GetByFilterAsync(x => x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber || x.PhoneNumber == dto.PhoneNumber);
            if (response.ResponseType == ResponseType.NotFound)
            {
                dto.UserTypeId = (int)AppUserType.Supplier;
                AppUser entity = _mapper.Map<Supplier>(dto);
                var result = await _userManager.CreateAsync(_mapper.Map<Supplier>(dto),dto.Password);
                if (!result.Succeeded) 
                    throw new SupplierBadRequestException("Satıcı eklenirken veritabanı kaynaklı bir sorun oluştu.");
                var roleResult = await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(entity.Email), "Supplier"); // todo role will add.
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

        public async Task RemoveSupplier(int supplierId)
        {
            var response = await base.GetByIdAsync(supplierId);
            if (response.ResponseType != ResponseType.NotFound)
                throw new SupplierNotFoundException($"{supplierId} id değerine sahip satıcı bulunamadı.");
            this.RemoveImage(response.Data.ImageUrl);
            await base.RemoveAsync(response.Data);

        }
        private void RemoveImage(string path)
        {
            _storage.RemoveFile(path);
        }
    }
}
