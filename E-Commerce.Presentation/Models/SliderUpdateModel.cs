using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    public class SliderUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; } = true;
    }
}
