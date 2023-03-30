using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Brand : BaseEntity
    {
        public string Defination { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
