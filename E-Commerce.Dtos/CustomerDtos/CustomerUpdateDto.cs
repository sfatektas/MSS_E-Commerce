using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.CustomerDtos
{
    public record CustomerUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int GenderId { get; init; }
        public double EarnedPoint { get; init; }
        public double CurrentPoint { get; init; }
    }
}
