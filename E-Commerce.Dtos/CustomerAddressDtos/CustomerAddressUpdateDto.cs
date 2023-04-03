using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.CustomerAddressDtos
{
    public record CustomerAddressUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public string City { get; init; }
        public string Town { get; init; }
        public string AddressDefination { get; init; }
        public bool SelectedAddress { get; init; }
    }
}
