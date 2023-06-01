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
    public interface IServiceRead<IListDto,T> 
        where IListDto : Dtos.Interfaces.IListDto , new()
        where T : BaseEntity, new()
    {
        public Task<IEnumerable<IListDto>> GetAllAsync();
        public IQueryable<T> GetQueryable();
        public Task<IEnumerable<IListDto>> GetAllAsync(Expression<Func<T,bool>> filter);
        public Task<IListDto> GetOneAsync(int id);
        Task<IListDto> GetOneAsync(Expression<Func<T, bool>> filter);
    }
}
