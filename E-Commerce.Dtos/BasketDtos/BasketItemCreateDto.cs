using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BasketDtos
{
    public class BasketItemCreateDto
    {
        public int ProductInStockId { get; set; }

        public int Amount { get; set; }     
    }
}
