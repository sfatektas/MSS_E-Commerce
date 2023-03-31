using E_Commerce.Common;
using E_Commerce.Dtos.SiteOptionDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ISiteOptionService
    {
        Task<Response<SiteOptionListDto>> GetOptionAsync();
    }
}
