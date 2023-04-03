using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Repositories.Abstract;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
