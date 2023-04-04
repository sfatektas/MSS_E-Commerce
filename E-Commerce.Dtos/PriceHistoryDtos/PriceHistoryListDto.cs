using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.PriceHistoryDtos
{
    public record PriceHistoryListDto : IListDto
    {
        public int Id { get; init; }
        public int SupplierProductsId { get; init; }
        public double OldPrice { get; init; }
        public double NewPrice { get; init; }
        public DateTime ModifiedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
