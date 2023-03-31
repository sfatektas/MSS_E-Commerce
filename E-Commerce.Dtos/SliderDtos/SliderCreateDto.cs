using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SliderDtos
{
    public record SliderCreateDto : ICreateDto
    {
        public string Name { get; init; }
    }
}
