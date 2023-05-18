using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.ProductCommentDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ProductCommentService : IProductCommentService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public ProductCommentService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddComment(ProductCommentCreateDto dto)
        {
            var entity = _mapper.Map<ProductComment>(dto);
            await _uow.GetRepository<ProductComment>().CreateAsync(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<ProductCommentListDto>> GetCommnets(int ProductInStockId)
        {
            var data = await _uow.GetRepository<ProductComment>()
                .GetAllAsync(x => x.SupplierProductId == ProductInStockId)
                .Include(x=>x.Customer)
                .ToListAsync();
            if (data.Count > 0)
            {
                var mappedData = _mapper.Map<List<ProductCommentListDto>>(data);
                return mappedData;
            }
            else
                throw new CommentNotFoundException("Bu ürüne ait yorum bulunmamaktadır");

        }
    }
}
