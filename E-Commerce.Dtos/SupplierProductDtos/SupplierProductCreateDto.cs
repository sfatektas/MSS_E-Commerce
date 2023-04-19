using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SupplierProductDtos
{
    public record SupplierProductCreateDto : ICreateDto
    {
        public int ProductId { get; init; }
        public int SizeId { get; init; }
        public int SupplierId { get; init; }
        public double UnitPrice { get; init; }
        public int ColorId { get; init; }
        public int Amount { get; init; }
        public string CustomProductTitle { get; init; }
        public string CustomProductDefination { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
    //TODO supplierCreateModelYapılacak.
}
