using E_Commerce.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class PriceHistory : BaseEntity
    {
        public int SupplierProductsId { get; set; }
        public SupplierProduct SupplierProducts { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
