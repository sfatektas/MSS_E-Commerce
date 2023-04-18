using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    public class SupplierProductCreateModel
    {
        public int ProductId { get; init; }
        public int SizeId { get; init; }
        public int SupplierId { get; init; }
        public double UnitPrice { get; init; }
        public int ColorId { get; init; }
        public string CustomProductTitle { get; init; }
        public string CustomProductDefination { get; init; }
        public List<IFormFile> Files { get; set; }
    }
}
