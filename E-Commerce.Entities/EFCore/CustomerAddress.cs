using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class CustomerAddress : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string City { get; set; }
        public string Town{ get; set; }
        public string AddressDefination { get; set; }
        public bool SelectedAddress{ get; set; }

    }
}
