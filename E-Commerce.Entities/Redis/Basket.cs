using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Redis
{
    public class Basket : BaseEntity
    {
        public int CustomerUsername { get; set; } // belki usernamealabiliriz.
        public List<BasketItem> BasketItems { get; set; }         
    }
}
