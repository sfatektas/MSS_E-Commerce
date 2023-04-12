using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.AppUserDtos
{
    public record AppUserListDto : IListDto
    {
        public int Id { get; init; }
        public int UserTypeId { get; init; }
        public bool IsActive { get; init; }
    }
}
