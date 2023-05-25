using AutoMapper;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SliderDtos;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Entities.EFCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISliderService : IService<SliderCreateDto, SliderListDto, SliderUpdateDto, Slider>
    {
        Task<List<SliderListDto>> GetAllSliderAsync();
        Task DeleteSliderAsync(int id);
        Task<SliderListDto> GetSliderById(int id);
        Task updateSlider(SliderUpdateDto dto);

    }
}
