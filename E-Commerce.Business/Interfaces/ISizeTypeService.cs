using E_Commerce.Common.Interfaces;
using E_Commerce.Dtos.SizeTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISizeTypeService
    {
        Task<IResponse<List<SizeTypeListDto>>> GetAllAsync();

    }
}
