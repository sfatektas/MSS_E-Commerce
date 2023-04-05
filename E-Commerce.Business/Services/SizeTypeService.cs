using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SizeTypeDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SizeTypeService : ISizeTypeService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public SizeTypeService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<SizeTypeListDto>>> GetAllAsync()
        {
            var SizeTypes =  await _uow.GetRepository<SizeType>().GetAllAsync().ToListAsync();
            if (!SizeTypes.Any())
                throw new SizeTypeNotFoundException();
            return new Response<List<SizeTypeListDto>>(Common.Enums.ResponseType.Success, _mapper.Map<List<SizeTypeListDto>>(SizeTypes));
        }

    }
}
