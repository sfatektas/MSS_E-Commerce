using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SupplierProductDtos
{
    public record SupplierProductUpdateDto: IUpdateDto
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public int SizeId { get; init; }
        public int SupplierId { get; init; }
        public double UnitPrice { get; init; }
        public int ColorId { get; init; }
        public string CustomProductTitle { get; init; }
        public string CustomProductDefination { get; init; }
        public int VisitCounter { get; init; }
        public double CompanyPoint { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
