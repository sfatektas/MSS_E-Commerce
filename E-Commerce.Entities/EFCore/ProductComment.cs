﻿using E_Commerce.Common;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductComment : BaseEntity
    {
        public Entities.EFCore.Identities.Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public ProductsInStock ProductsInStock { get; set; }
        public int ProductsInStockId { get; set; }
        public string Content { get; set; }
        public int  Point { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);

    }
}
