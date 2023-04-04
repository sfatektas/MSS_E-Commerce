using E_Commerce.Common;
using E_Commerce.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryListDto>>> GetAllCategory();
    }
}
