using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Models
{
    public class CustomerOrderListModel
    {
        public string OrderStatusValue { get; set; }
        public OrderStatusType OrderStatusType { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<CustomerOrderDetailListModel> CustomerOrderDetails{ get; set; }


    }

    public class CustomerOrderDetailListModel
    {           
        public int ProductInStockId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDefination { get; set; }
        public string SupplierUsername { get; set; }
        public int SupplierId { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}
