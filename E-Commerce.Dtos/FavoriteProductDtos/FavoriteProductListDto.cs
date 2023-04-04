using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.FavoriteProductDtos
{
    public record FavoriteProductListDto : IListDto
    {
        public int Id { get; init; }
        public int SupplierProdcutsId { get; init; }
        public int CustomerId { get; init; }
    }
}
