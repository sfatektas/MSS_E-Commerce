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

        private int _minPrice;

        public int MinPrice
        {
            get
            {
                return this._minPrice;
            }
            set
            {
                _minPrice = value < 0 ? 0 : value;  
            }
        }

        public int MaxPrice { get; set; } = int.MaxValue;

        public string Search { get; set; }
    }
}
