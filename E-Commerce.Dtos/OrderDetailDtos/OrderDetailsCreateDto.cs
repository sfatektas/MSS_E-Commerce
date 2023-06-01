﻿using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.OrderDetailDtos
{
    public record OrderDetailsCreateDto : ICreateDto
    {
        //public int OrderId { get; init; }
        public int SupplierProductId { get; init; }
        public int Amount { get; init; }
        public double UnitPrice { get; init; }
        public double TotalPrice { get; init; }
    }
}
