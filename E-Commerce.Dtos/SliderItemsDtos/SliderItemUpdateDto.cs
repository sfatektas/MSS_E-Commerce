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
        public int SliderId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
    }
}
