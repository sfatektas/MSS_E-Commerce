using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Slider : BaseEntity
    {
        public string Name { get; set; }

        public List<SliderItem> SliderItems { get; set; }
    }
}
