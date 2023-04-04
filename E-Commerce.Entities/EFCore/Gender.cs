using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Gender : BaseEntity
    {
        //Todo SeedData eklenecek
        public string Defination { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
