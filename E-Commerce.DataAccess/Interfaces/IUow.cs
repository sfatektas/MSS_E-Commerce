using E_Commerce.DataAccess.Repositories.Abstract;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Interfaces
{
    public interface IUow
    {
        public Repository<T> GetRepository<T>() where T : BaseEntity, IBaseEntity, new();

        public Task SaveChangesAsync();
    }
}
