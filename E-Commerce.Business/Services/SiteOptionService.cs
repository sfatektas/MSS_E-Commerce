using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SiteOptionDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SiteOptionService :ISiteOptionService
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
            var data = await _uow.GetRepository<SiteOption>().GetAllAsync();
            if(data != null)
                return new Response<SiteOptionListDto>(Common.Enums.ResponseType.Success, _mapper.Map<SiteOptionListDto>(data.FirstOrDefault()));
            return new Response<SiteOptionListDto>(Common.Enums.ResponseType.NotFound, null);
        }
    }
}
