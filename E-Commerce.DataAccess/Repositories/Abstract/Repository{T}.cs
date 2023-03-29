using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories.Abstract
{
    public class Repository<T> where T : BaseEntity , new()
    {
    }
}
