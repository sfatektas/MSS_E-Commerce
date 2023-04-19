using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Redis
{
    public class BasketItem : BaseEntity
    {
        public int ProductInStockId { get; set; }

        public int Amount { get; set; }
    }
}
