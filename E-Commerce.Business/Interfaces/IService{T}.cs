using E_Commerce.Common.Interfaces;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IService<CreateDto, ListDto, UpdateDto, T> where CreateDto : class, ICreateDto
          where ListDto : class, IListDto
          where UpdateDto : class, IUpdateDto
          where T : BaseEntity
    {

        Task<IResponse<CreateDto>> CreateAsync(CreateDto model);

        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto model);

        Task<IResponse<ListDto>> GetByIdAsync(int id);

        Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T, bool>> filter);

        Task<IResponse> RemoveAsync(ListDto dto);

        Task<IResponse<List<ListDto>>> GetAllAsync();

        Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter);

    }
}
