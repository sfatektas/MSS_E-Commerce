using E_Commerce.Common;
using E_Commerce.Dtos.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IColorService
    {
        Task<Response<List<ColorListDto>>> GetAllColor();

    }
}
