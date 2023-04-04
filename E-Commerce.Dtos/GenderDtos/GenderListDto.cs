using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.GenderDtos
{
    public record GenderListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        public List<CustomerListDto> Customers { get; init; }
    }
}
