using E_Commerce.Dtos.SizeDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISizeService : IServiceRead<SizeListDto , Size>
    {
        Task<IEnumerable<SizeListDto>> GetAllSize();
        Task<IEnumerable<SizeListDto>> GetAllSize(Expression<Func<Size, bool>> filter);
        Task<SizeListDto> GetOneSizeAsync(int id);
        Task<SizeListDto> GetOneSizeAsync(Expression<Func<Size, bool>> filter);
    }
}
