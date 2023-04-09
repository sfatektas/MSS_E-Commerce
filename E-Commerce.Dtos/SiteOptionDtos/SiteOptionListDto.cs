using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SiteOptionDtos
{
    public record SiteOptionListDto : IListDto
    {
        public int Id { get; init; }
        public string Logo { get; init; }
        public string Slogan { get; init; }
        public string FacebookLink { get; init; }
        public string TwitterLink { get; init; }
        public string LinkedInLink { get; init; }
        public string PinterestLink { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string Adress { get; init; }
    }
}
