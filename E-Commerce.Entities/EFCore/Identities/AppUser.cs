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
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool IsActive { get; set; }
    }
}
