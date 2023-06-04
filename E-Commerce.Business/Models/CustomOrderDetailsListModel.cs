using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Models
{
    public class CustomOrderDetailsListModel
    {
        public string Title{ get; set; }
        public string Definition { get; set; }
        public double UnitPrice{ get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int SupplierProductInStockId { get; set; }
        public string SupplierProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
