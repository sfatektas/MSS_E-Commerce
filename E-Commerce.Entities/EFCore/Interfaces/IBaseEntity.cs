using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore.Interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}
