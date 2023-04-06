using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Entities.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ServiceRead<ListDto, T> : IServiceRead<ListDto, T>
        where ListDto : Dtos.Interfaces.IListDto, new()
        where T : BaseEntity, new()
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public ServiceRead(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ListDto>>(await _uow.GetRepository<T>()
                .GetAllAsync()
                .ToListAsync());
        }

        public async Task<IEnumerable<ListDto>> GetAll(Expression<Func<T, bool>> filter)
        {
            return _mapper.Map<IEnumerable<ListDto>>(await _uow.GetRepository<T>()
                .GetAllAsync(filter)
                .ToListAsync());
        }

        public async Task<ListDto> GetOne(int id)
        {
            return _mapper.Map<ListDto>(await _uow.GetRepository<T>()
                .GetByFilterAsync(x => x.Id == id));
        }

        public async Task<ListDto> GetOne(Expression<Func<T,bool>> filter)
        {
            return _mapper.Map<ListDto>(await _uow.GetRepository<T>()
                .GetByFilterAsync(filter));
        }
    }
}
