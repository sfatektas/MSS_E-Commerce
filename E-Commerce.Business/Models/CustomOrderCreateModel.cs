using E_Commerce.Common;
using E_Commerce.Common.Enums;
using E_Commerce.Dtos.OrderDetailDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Models
{
    public class CustomOrderCreateModel
    {
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string AddressDetail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
        public List<OrderDetailsCreateDto> OrderDetails { get; set; }

    }
}
