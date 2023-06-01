using E_Commerce.Dtos.OrderDetailDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.OrderDetailValidation
{
    public class OrderDetailCreateDtoValidator : AbstractValidator<OrderDetailsCreateDto>
    {
        public OrderDetailCreateDtoValidator()
        {
            //RuleFor(x => x.OrderId).NotEqual(0).WithMessage("Order Id alanı bos gecilemez");
            RuleFor(x => x.ProductInStockId).NotEqual(0).WithMessage("Product Stock Id alanı bos gecilemez");
            RuleFor(x => x.Amount).NotEqual(0).WithMessage("Amount alanı bos gecilemez");
        }
    }
}
