using E_Commerce.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Models
{
    public class SupplierProductUpdateModel
    {
        public int Id { get; init; }
        public int SizeId { get; init; }
        public double UnitPrice { get; init; }
        public int ColorId { get; init; }
        public string CustomProductTitle { get; init; }
        public string CustomProductDefination { get; init; }
        public List<IFormFile> Files { get; set; } = new();
        public bool IsActive { get; set; }
    }
}
