using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SliderDtos
{
    public record SliderUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public bool isActive { get; set; }
    }
}
