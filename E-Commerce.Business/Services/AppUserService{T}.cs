using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.Common.Enums;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class AppUserService<CreateDto, ListDto, UpdateDto, T> : IAppUserService<CreateDto, ListDto, UpdateDto, T>
        where CreateDto : class ,ICreateDto, new()
        where ListDto : class , IListDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where T : AppUser, new()
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public AppUserService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto) // mapper olarak 
        {
            var entity = _mapper.Map<T>(dto);
            await _uow.GetIdentityRepository<T>().CreateAsync(entity);
            await _uow.SaveChangesAsync();
            return new Response<CreateDto>(Common.Enums.ResponseType.Success , dto);
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetIdentityRepository<T>().GetAllAsync();
            if (data == null)
                return new Response<List<ListDto>>(ResponseType.NotFound, null);
            return new Response<List<ListDto>>(ResponseType.Success, _mapper.Map<List<ListDto>>(data));
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _uow.GetIdentityRepository<T>().GetAllAsync(filter);
            if (data == null)
                return new Response<List<ListDto>>(ResponseType.NotFound, null);
            return new Response<List<ListDto>>(ResponseType.Success, _mapper.Map<List<ListDto>>(data));
        }

        public async Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _uow.GetIdentityRepository<T>().GetByFilterAsync(filter);
            if (data == null)
                return new Response<ListDto>(ResponseType.NotFound, null);
            return new Response<ListDto>(ResponseType.Success, _mapper.Map<ListDto>(data));
        }

        public async Task<IResponse<ListDto>> GetByIdAsync(int id)
        {
            var data = await _uow.GetIdentityRepository<T>().FindAsync(id);
            return new Response<ListDto>(ResponseType.Success, _mapper.Map<ListDto>(data));
        }

        public Task<IResponse> RemoveAsync(ListDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var unchanged = await _uow.GetIdentityRepository<T>().FindAsync(dto.Id);
            if (unchanged != null)
            {
                _uow.GetIdentityRepository<T>().Update(_mapper.Map<T>(dto));
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            return new Response<UpdateDto>( ResponseType.NotFound, dto);

        }
    }
}
