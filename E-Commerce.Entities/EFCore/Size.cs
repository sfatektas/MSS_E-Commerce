using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Size : BaseEntity
    {
        public string Value { get; set; }
        public SizeType SizeType { get; set; }
        public int SizeTypeId { get; set; }
        public List<SupplierProduct> SupplierProducts { get; set; }
    }
}
