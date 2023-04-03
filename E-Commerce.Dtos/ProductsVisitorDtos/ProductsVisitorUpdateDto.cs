using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsVisitorDtos
{
    public record ProductsVisitorUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public int SupplierProductId { get; init; }
        public DateTime VisitDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
