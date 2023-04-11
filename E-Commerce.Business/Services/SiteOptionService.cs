using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SiteOptionDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SiteOptionService : ISiteOptionService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public SiteOptionService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<SiteOptionListDto>> GetOptionAsync()
        {
            var data = await _uow.GetRepository<SiteOption>().GetAllAsync().ToListAsync();
            if (data != null)
                return new Response<SiteOptionListDto>(Common.Enums.ResponseType.Success, _mapper.Map<SiteOptionListDto>(data.FirstOrDefault()));
            return new Response<SiteOptionListDto>(Common.Enums.ResponseType.NotFound, null);
        }

        public async Task UpdateOptionAsync(SiteOptionUpdateDto dto)
        {
            var data = await _uow.GetRepository<SiteOption>().GetByFilterAsync(x=>x.Id == dto.Id);
            if (data == null)
                throw new SiteOptionNotFoundException($"{dto.Id} ıd değerine sahip bir site option kaydı bulunamadı.");
            var entity = _mapper.Map<SiteOption>(dto);
            _uow.GetRepository<SiteOption>().Update(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
