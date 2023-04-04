using E_Commerce.Dtos.AppUserDtos;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.UserTypeDtos
{
    public record UserTypeListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        public List<AppUserListDto> AppUsers { get; init; }
    }
}
