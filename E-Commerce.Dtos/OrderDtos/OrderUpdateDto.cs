using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.OrderDtos
{
    public record OrderUpdateDto:IUpdateDto
    {
        public int Id{ get; init; }
        public int CustomerId { get; init; }
        public int OrderStatusTypeId { get; init; }
        public double TotalPrice { get; init; }
        public string City { get; init; }
        public string Town { get; init; }
        public string AddressDetail { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
