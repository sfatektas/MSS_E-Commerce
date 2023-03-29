using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class SliderItem : BaseEntity
    {
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
        public string ImageUrl{ get; set; }
        public string Title{ get; set; }
        public string SubTitle{ get; set; }

    }
}
