using AutoMapper;
using Azure;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
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
    public class SliderItemService : Service<SliderItemCreateDto,SliderItemListDto,SliderItemUpdateDto,SliderItem>,ISliderItemService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public SliderItemService(IUow uow, IMapper mapper,IValidator<SliderItemCreateDto> createValidator) : base(uow,mapper,createValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<SliderItemListDto>> GetAllSliderItemAsync()
        {
            var sliderItems = await _uow.GetRepository<SliderItem>().
                GetQueryable()
                .Include(x=>x.Slider)
                .ToListAsync();

            if(sliderItems == null)
                throw new SliderItemNotFoundException();
            return _mapper.Map<List<SliderItemListDto>>(sliderItems);
            
        }

        public async Task<SliderItemListDto> GetSliderItemById(int id)
        {
            var response = await base.GetByIdAsync(id);
            if (response.Data == null)
                throw new SliderItemNotFoundException();
            return response.Data;
        }
        
    }
}
