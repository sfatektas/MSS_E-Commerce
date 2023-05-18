using E_Commerce.Dtos.ProductCommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IProductCommentService
    {
        Task AddComment(ProductCommentCreateDto dto);

        Task<List<ProductCommentListDto>> GetCommnets(int ProductInStockId);



    }
}
