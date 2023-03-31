using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductCommentDtos
{
    public record ProductCommentCreateDto : ICreateDto
    {
        public int CustomerId { get; init; }
        public int SupplierProductId { get; init; }
        public string Content { get; init; }
        public int Point { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
