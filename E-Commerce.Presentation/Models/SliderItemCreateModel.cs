using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    public class SliderItemCreateModel
    {
        public int SliderId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public IFormFile File { get; set; }

    }
}
