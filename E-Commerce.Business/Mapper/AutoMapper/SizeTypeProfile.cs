using AutoMapper;
using E_Commerce.Dtos.SizeTypeDtos;
using E_Commerce.Entities.EFCore;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class SizeTypeProfile : Profile
    {
        public SizeTypeProfile()
        {
            CreateMap<SizeType, SizeTypeListDto>();
        }
    }
}
