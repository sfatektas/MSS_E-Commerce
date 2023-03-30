using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyUserName { get; set; }
        public string CompanyDetail { get; set; }
        public string ImageUrl { get; set; }

        public List<SupplierProduct> SupplierProducts { get; set; }

        //TODO appUser tablosuna ilişki verilecek.

        public AppUser AppUser { get; set; }
    }
}
