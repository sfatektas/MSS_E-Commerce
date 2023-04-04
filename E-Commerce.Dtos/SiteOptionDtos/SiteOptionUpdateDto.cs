using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SiteOptionDtos
{
    public class SiteOptionUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public string Logo { get; set; }
        public string Slogan { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public string PinterestLink { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
