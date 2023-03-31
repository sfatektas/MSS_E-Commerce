using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class SizeType : BaseEntity
    {
        //Todo SeedData eklenecek
        public string Defination { get; set; }
        public List<Size> Sizes { get; set; }
    }
}
