using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class UserType : BaseEntity
    {
        //Todo SeedData eklenecek
        public string Defination { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
