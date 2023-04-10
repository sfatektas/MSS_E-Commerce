using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SliderItemsDtos
{
    public record SliderItemUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public int SliderId { get; init; }
        public string ImageUrl { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ButtonText { get; init; }
        public string ButtonLink { get; init; }
    }
}
