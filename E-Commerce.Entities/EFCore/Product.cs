using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Product : BaseEntity
    {
        public int BrantId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int SizeTypeId { get; set; }
        public SizeType SizeType { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }

        public List<SupplierProduct> SupplierProducts { get; set; }
    }
}
