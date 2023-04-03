using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Interfaces
{
    public interface ICustomerRepository : IIdentityRepository<Customer>
    {
    }
}
