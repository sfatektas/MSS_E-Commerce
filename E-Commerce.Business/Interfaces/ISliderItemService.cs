using E_Commerce.Common.Interfaces;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISliderItemService : IService<SliderItemCreateDto,SliderItemListDto,SliderItemUpdateDto, SliderItem>
    {
        Task<List<SliderItemListDto>> GetAllSliderItemAsync();
        Task<SliderItemListDto> GetSliderItemById(int id);
    }
}
