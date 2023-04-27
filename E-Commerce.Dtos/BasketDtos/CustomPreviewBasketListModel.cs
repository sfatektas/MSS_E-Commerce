using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BasketDtos
{
    public class CustomPreviewBasketListModel
    {
        public string Title { get; set; }

        public string Brand { get; set; }

        public string ImageUrl { get; set; }

        public double UnitPrice { get; set; }
    }
}
