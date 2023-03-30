using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class CustomerAddress : BaseEntity
    {
        public Entities.EFCore.Identities.Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string Town{ get; set; }
        public string AddressDefination { get; set; }
        public bool SelectedAddress{ get; set; }
    }
}
