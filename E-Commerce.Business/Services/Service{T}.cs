using AutoMapper;
using E_Commerce.Business.Extenisons;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.Common.Enums;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Entities.EFCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class Service<CreateDto, ListDto, UpdateDto, T> : IService<CreateDto, ListDto, UpdateDto, T>
            where CreateDto : class, ICreateDto , new()
            where ListDto : class, IListDto , new()
            where UpdateDto : class, IUpdateDto , new()
            where T : BaseEntity , new()
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        readonly IValidator<CreateDto> _createValidator;
        //Update Validator eklenecek



        public Service(IUow uow, IMapper mapper, IValidator<CreateDto> createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
        }
        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync().ToListAsync();
            if (data != null)
                return new Response<List<ListDto>>(ResponseType.Success, _mapper.Map<List<ListDto>>(data));
            else
                return new Response<List<ListDto>>(ResponseType.NotFound, _mapper.Map<List<ListDto>>(data));
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = await _createValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _uow.GetRepository<T>().CreateAsync(_mapper.Map<T>(dto));
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            else
                return new Response<CreateDto>(ResponseType.ValidationError, "validasyon hatası", dto, result.GetValidationErrors());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var result = await _uow.GetRepository<T>().GetAllAsync(filter).ToListAsync();
            if (result.Count > 0)
                return new Response<List<ListDto>>(ResponseType.Success, _mapper.Map<List<ListDto>>(result));
            return new Response<List<ListDto>>(ResponseType.NotFound, _mapper.Map<List<ListDto>>(result));
        }

        public async Task<IResponse<ListDto>> GetByIdAsync(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data != null)
            {
                return new Response<ListDto>(ResponseType.Success, _mapper.Map<ListDto>(data));
            }
            return new Response<ListDto>(ResponseType.NotFound, "Böyle bir kayıta ulaşılamadı.", _mapper.Map<ListDto>(data));
        }

        public async Task<IResponse> RemoveAsync(ListDto dto)
        {
            _uow.GetRepository<T>().Remove(_mapper.Map<T>(dto));
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            try
            {
                _uow.GetRepository<T>().Update(await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == dto.Id), _mapper.Map<T>(dto));
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            catch (Exception e)
            {
                return new Response<UpdateDto>(ResponseType.Error, $"Bir sorun oluştu Hata mesajı : {e.Message}", dto);
            }
        }

        public async Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(filter);
            if (data == null)
                return new Response<ListDto>(ResponseType.NotFound, _mapper.Map<ListDto>(data));

            return new Response<ListDto>(ResponseType.Success, _mapper.Map<ListDto>(data));
        }

    }
}
