using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Validations.FluentValidations.SliderValidation;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SliderDtos;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SliderService : Service<SliderCreateDto, SliderListDto, SliderUpdateDto, Slider>, ISliderService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public SliderService(IUow uow, IMapper mapper, IValidator<SliderCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<SliderListDto>> GetAllSliderAsync()
        {
            var sliders = await _uow.GetRepository<Slider>().GetQueryable().
                Include(x => x.SliderItems).ToListAsync();

            if (sliders == null)
                throw new SliderNotFoundException();
            return _mapper.Map<List<SliderListDto>>(sliders);
        }


        public async Task DeleteSliderAsync(int id)
        {
            var slider = await _uow.GetRepository<Slider>().GetByFilterAsync(x => x.Id == id);

            if (slider != null)
                await base.RemoveAsync(_mapper.Map<SliderListDto>(slider));
            else
                throw new SliderNotFoundException("Böyle bir slider bulunamadı");

        }

    }
}
