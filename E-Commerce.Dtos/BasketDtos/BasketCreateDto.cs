using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BasketDtos
{
    public class BasketCreateDto
    {
        public string CustomerUsername { get; set; }

        public List<BasketItemCreateAndUpdateDto> BasketItems { get; set; }
    }
}
