using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Gender : BaseEntity
    {
        public string Defination { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
