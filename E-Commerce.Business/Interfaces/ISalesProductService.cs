using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISalesProductService
    {
        Task<PagedList<CustomPreviewProductInStockListDto>> GetProductFromParameter(SalesProductRequestParameter parameter);
    }
}
