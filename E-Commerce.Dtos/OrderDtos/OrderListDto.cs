using E_Commerce.Common;
using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.OrderDetailDtos;
using E_Commerce.Dtos.OrderStatusTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.OrderDtos
{
    public record OrderListDto : IListDto
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public CustomerListDto Customer { get; set; }
        public int OrderStatusTypeId { get; init; }
        public OrderStatusTypeListDto OrderStatusType { get; set; }
        public double TotalPrice { get; init; }
        public string City { get; init; }
        public string Town { get; init; }
        public string AddressDetail { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
        public List<OrderDetailListDto> OrderDetails { get; set; }
    }
}
