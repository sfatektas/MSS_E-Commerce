using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Entities.RequestFeatures.Abstract;

namespace E_Commerce.Entities.RequestFeatures
{
    public class SupplierProductRequestParameter : RequestParameter
    {
        public string Color { get; set; }

        public string Size { get; set; }

        public int MinPrice
        {
            get
            {
                return this.MinPrice;
            }
            set
            {
                MinPrice = value < 0 ? 0 : value;  
            }
        }

        public int MaxPrice { get; set; }

        public string Search { get; set; }
    }
}
