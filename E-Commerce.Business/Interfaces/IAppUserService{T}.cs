using E_Commerce.Common.Interfaces;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IAppUserService<CreateDto, ListDto, UpdateDto, T>
        where CreateDto : ICreateDto, new()
        where ListDto : IListDto, new()
        where UpdateDto : IUpdateDto, new()
        where T : AppUser, new()
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<ListDto>> GetByIdAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T,bool>> filter);
        Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse> RemoveAsync(ListDto dto);
    }
}
