using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.ColorDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ColorService : IColorService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public ColorService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<List<ColorListDto>>> GetAllColor()
        {
            var colors = await _uow.GetRepository<Entities.EFCore.Color>().GetAllAsync().ToListAsync();
            if (!colors.Any())
                throw new ColorNotFoundException();
            return new Response<List<ColorListDto>>(Common.Enums.ResponseType.Success, _mapper.Map<List<ColorListDto>>(colors));
        }

        
    }
}
