using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        //public Gender Gender { get; set; }
        public double EarnedPoint { get; set; }
        public double CurrentPoint { get; set; }

        public List<FavoriteProduct> FavoriteProducts { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }

        public List<ProductsVisitor> ProductsVisitors { get; set; }

        public List<ProductComment> ProductComments{ get; set; }

        public List<Order> Orders { get; set; }

        public List<Gender> Genders { get; set; }

        //AppUser sınıfından kalıtılacak
        public AppUser AppUser { get; set; }
    }
}
