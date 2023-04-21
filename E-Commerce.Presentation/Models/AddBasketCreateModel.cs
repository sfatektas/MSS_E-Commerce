using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    public class AddBasketCreateModel
    {
        public string Username { get; set; }

        public int ProductInStockId { get; set; }

        public int Amount { get; set; }

    }
}
