﻿using E_Commerce.Common;
using E_Commerce.Dtos.ColorDtos;
using E_Commerce.Dtos.FavoriteProductDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.OrderDetailDtos;
using E_Commerce.Dtos.PriceHistoryDtos;
using E_Commerce.Dtos.ProductCommentDtos;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Dtos.ProductImageDtos;
using E_Commerce.Dtos.ProductsVisitorDtos;
using E_Commerce.Dtos.SizeDtos;
using E_Commerce.Dtos.SupplierAddingProductDtos;
using E_Commerce.Dtos.SupplierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SupplierProductDtos
{
    public record SupplierProductListDto : IListDto
    {
        public int Id { get; init; }

        public ProductListDto Product { get; set; }
        public int ProductId { get; init; }
        public SizeListDto Size { get; set; }
        public int SizeId { get; init; }
        public SupplierListDto Supplier { get; set; }
        public int SupplierId { get; init; }
        public double UnitPrice { get; init; }
        public int ColorId { get; init; }
        public ColorListDto Color { get; set; }
        public string CustomProductTitle { get; init; }
        public string CustomProductDefination { get; init; }
        public int VisitCounter { get; init; }
        public double CompanyPoint { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);
        public List<PriceHistoryListDto> PriceHistories { get; init; }
        public List<ProductCommentListDto> ProductComments { get; init; }
        public List<ProductImageListDto> ProductImages { get; init; }

        //public List<SupplierAddingProductListDto> SupplierAddingProducts { get; init; }
        //public List<OrderDetailListDto> OrderDetails { get; init; }
        //public List<ProductsVisitorListDto> ProductsVisitors { get; init; }
        //public List<FavoriteProductListDto> FavoriteProducts { get; init; }
    }
}
