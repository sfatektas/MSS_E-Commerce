using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SizeDtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SizeTypeDtos
{
    public record SizeTypeListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        public List<SizeListDto> Sizes { get; init; }

    }
}
