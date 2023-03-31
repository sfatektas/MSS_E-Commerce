using E_Commerce.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Order : BaseEntity
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Entities.EFCore.Identities.Customer Customer { get; set; }
        public int OrderStatusTypeId { get; set; }
        public OrderStatusType OrderStatusType { get; set; }
        public double TotalPrice { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string AddressDetail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
