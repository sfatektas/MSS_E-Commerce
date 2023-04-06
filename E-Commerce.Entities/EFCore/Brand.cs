using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Brand : BaseEntity
    {
        public string Defination {
            get { return Defination; } 
            set { Defination = value.ToLower();}  // marka adları uniq olacağı için hepsini büyük küçük harf duyarlı olarak küçük harfe çeviriyorum.
        }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
