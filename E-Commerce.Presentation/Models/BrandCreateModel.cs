using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    public class BrandCreateModel
    {
        public string Defination { get; init; }
        public string ImageUrl { get; init; }
        public IFormFile File { get; set; }
    }
}
