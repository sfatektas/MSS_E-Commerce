using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SliderItemsDtos
{
    public record SliderItemCreateDto : ICreateDto
    {
        public int SliderId { get; init; }
        public string ImageUrl { get; set; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ButtonText { get; init; }
        public string ButtonLink { get; init; }
    }
}
