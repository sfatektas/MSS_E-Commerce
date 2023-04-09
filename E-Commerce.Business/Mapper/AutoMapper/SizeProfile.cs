using AutoMapper;
using E_Commerce.Dtos.SizeDtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Entities.EFCore.Size , SizeListDto>().ReverseMap();
        }
    }
}
