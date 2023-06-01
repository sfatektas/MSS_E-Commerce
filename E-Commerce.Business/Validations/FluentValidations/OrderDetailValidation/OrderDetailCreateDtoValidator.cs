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
            RuleFor(x => x.SupplierProductId).NotEqual(0).WithMessage("Supplier Product Id alanı bos gecilemez");
            RuleFor(x => x.UnitPrice).NotEqual(0).WithMessage("Amount alanı bos gecilemez");
            RuleFor(x => x.TotalPrice).NotEqual(0).WithMessage("Total Price alanı bos gecilemez");
            RuleFor(x => x.Amount).NotEqual(0).WithMessage("Amount alanı bos gecilemez");
        }
    }
}
