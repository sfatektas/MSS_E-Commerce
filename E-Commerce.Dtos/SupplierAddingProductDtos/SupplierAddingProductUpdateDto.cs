using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SupplierAddingProductDtos
{
    public record SupplierAddingProductUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public int SupplierProductId { get; init; }
        public double UnitPrice { get; init; }
        public int Amount { get; init; }
        public DateTime Date { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
