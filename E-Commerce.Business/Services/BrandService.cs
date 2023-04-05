using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class BrandService : ServiceRead<BrandListDto, Brand>, IBrandService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public BrandService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrandListDto>> GetAllBrand()
        {
            var data = await base.GetAll();
            if (data != null)
                return data;
            throw new BrandNotFoundException();
        }

        public async Task AddBrand(BrandCreateDto dto)
        {
            await _uow.GetRepository<Brand>()
                .CreateAsync(_mapper.Map<Brand>(dto));
            await _uow.SaveChangesAsync();
        }
    }
}
