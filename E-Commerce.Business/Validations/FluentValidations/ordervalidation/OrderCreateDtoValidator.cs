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
            RuleFor(x => x.CustomerId).NotEqual(0).WithMessage("Customer Id'si bos gecilemez");
            RuleFor(x => x.OrderStatusTypeId).NotEqual(0).WithMessage("Order Durumu bos gecilemez");
            RuleFor(x => x.TotalPrice).NotEqual(0).WithMessage("Toplam ucret alanı bos gecilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Sehir alanı bos gecilmez");
            RuleFor(x => x.Town).NotEmpty().WithMessage("Ilce alanı bos gecilemez");
            RuleFor(x => x.AddressDetail).NotEmpty().WithMessage("Adres alanı bos gecilemez");
        }
    }
}
