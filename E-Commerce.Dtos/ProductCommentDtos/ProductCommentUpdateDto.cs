﻿using E_Commerce.Common;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductCommentDtos
{
    public record ProductCommentUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public int ProductInStockId { get; set; }
        public int CustomerId { get; set; }
        public string Content { get; init; }
        public int Point { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
    }
}
