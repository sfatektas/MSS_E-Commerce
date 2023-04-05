using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IBrandService : IServiceRead<BrandListDto, Brand>
    {
        Task AddBrand(BrandCreateDto dto);
        Task<IEnumerable<BrandListDto>> GetAllBrand();

    }
}
