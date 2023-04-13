using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using E_Commerce.Entities.RequestFeatures;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SupplierProductService : Service<SupplierProductCreateDto, SupplierProductListDto, SupplierProductUpdateDto, SupplierProduct>, ISupplierProductService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public SupplierProductService(IUow uow, IMapper mapper, IValidator<SupplierProductCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
            _uow= uow;
            _mapper= mapper;
        }
        public async Task<List<SupplierProductListDto>> GetAllWithRequestParameter(SupplierProductRequestParameter parameter)
        {
            var data = await _uow.GetRepository<SupplierProduct>()
                .GetQueryable()
                .Include(x=>x.Color)
                .Include(x=>x.Size)
                .Where(x => (x.UnitPrice >= parameter.MinPrice && x.UnitPrice <= parameter.MaxPrice)
                            && string.IsNullOrWhiteSpace(parameter.Color) ? true : x.Color.Defination.Contains(parameter.Color)
                            && string.IsNullOrWhiteSpace(parameter.Size) ? true : x.Size.Value.Contains(parameter.Size))
                .Skip(parameter.PageSize - 1 * parameter.PageNumber)
                .Take(parameter.PageSize)
                .ToListAsync();
            if (data == null)
                throw new SupplierProductNotFoundException("Aranan kriterlere uygun ürün bulunamadı.");
            return _mapper.Map<List<SupplierProductListDto>>(data);
        }   
    }
}
