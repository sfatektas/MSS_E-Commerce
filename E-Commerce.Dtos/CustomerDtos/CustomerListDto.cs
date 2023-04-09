using E_Commerce.Dtos.CustomerAddressDtos;
using E_Commerce.Dtos.FavoriteProductDtos;
using E_Commerce.Dtos.GenderDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Dtos.ProductCommentDtos;
using E_Commerce.Dtos.ProductsVisitorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.CustomerDtos
{
    public record CustomerListDto : IListDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public GenderListDto Gender { get; init; }
        public int GenderId { get; init; }
        public double EarnedPoint { get; init; }
        public double CurrentPoint { get; init; }

        //public List<FavoriteProductListDto> FavoriteProducts { get; init; }

        //public List<CustomerAddressListDto> CustomerAddresses { get; init; }

        //public List<ProductsVisitorListDto> ProductsVisitors { get; init; }

        //public List<ProductCommentListDto> ProductComments { get; init; }

        //public List<OrderListDto> Orders { get; init; }

    }
}
