using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SliderItemsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SliderDtos
{
    public record SliderListDto : IListDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public List<SliderItemListDto> SliderItems { get; init; }
    }
}
