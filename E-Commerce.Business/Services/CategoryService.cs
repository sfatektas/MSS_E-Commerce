using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.CategoryDtos;
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
    public class CategoryService : ICategoryService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public CategoryService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryListDto>>> GetAllCategory()
        {
            var categories = await _uow.GetRepository<Category>().GetAllAsync().ToListAsync();
            if (!categories.Any())
                throw new CategoryNotFoundException();
            return new Response<List<CategoryListDto>>(Common.Enums.ResponseType.Success , _mapper.Map<List<CategoryListDto>>(categories));
        }
    }
}
