using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Repositories.Abstract;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories.IdentitiyRepositories
{
    public class CustomerRepository : IdentityRepository<Customer>
    {
        public CustomerRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
