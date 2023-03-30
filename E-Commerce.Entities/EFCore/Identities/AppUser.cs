using E_Commerce.Entities.EFCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore.Identities
{
    public class AppUser : IdentityUser<int> , IBaseEntity
    {
        public bool IsActive { get; set; }
    }
    public class Supplier : AppUser
    {
        public string CompanyName { get; set; }
        public string CompanyUserName { get; set; }
        public string CompanyDetail { get; set; }
        public string ImageUrl { get; set; }

        public List<SupplierProduct> SupplierProducts { get; set; }
    }
    public class Customer : AppUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public double EarnedPoint { get; set; }
        public double CurrentPoint { get; set; }

        public List<FavoriteProduct> FavoriteProducts { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }

        public List<ProductsVisitor> ProductsVisitors { get; set; }

        public List<ProductComment> ProductComments { get; set; }

        public List<Order> Orders { get; set; }


    }
    public class Admin : AppUser
    {
        public string FirstName { get; set; }
    }
}
