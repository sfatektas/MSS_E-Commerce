using E_Commerce.Dtos.OrderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.OrderValidation
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x=>x.OrderStatusTypeId).NotEmpty();
            RuleFor(x=>x.TotalPrice).NotEmpty();
            RuleFor(x=>x.City).NotEmpty();
            RuleFor(x=>x.Town).NotEmpty();
            RuleFor(x=>x.AddressDetail).NotEmpty();
        }
    }
}
