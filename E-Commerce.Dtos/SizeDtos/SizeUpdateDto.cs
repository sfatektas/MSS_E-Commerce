using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SizeDtos
{
    public record SizeUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public string Value { get; init; }
        public string SizeTypeId { get; init; }
    }
}
