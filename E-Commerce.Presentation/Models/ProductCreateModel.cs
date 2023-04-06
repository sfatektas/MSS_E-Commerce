using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    public class ProductCreateModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int SizeTypeId { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File { get; set; }
    }
}
