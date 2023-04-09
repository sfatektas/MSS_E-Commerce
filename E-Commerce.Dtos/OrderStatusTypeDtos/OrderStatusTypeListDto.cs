using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.OrderStatusTypeDtos
{
    public record OrderStatusTypeListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        //public List<OrderListDto> Orders { get; init; }
    }
}
