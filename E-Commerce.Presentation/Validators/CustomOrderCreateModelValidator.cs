using E_Commerce.Presentation.Models;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class CustomOrderCreateModelValidator : AbstractValidator<Business.Models.CustomOrderCreateModel>
    {
        public CustomOrderCreateModelValidator()
        {
            RuleFor(x => x.CustomerId).NotEqual(0).WithMessage("Customer Id'si bos gecilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Sehir alanı bos gecilmez");
            RuleFor(x => x.Town).NotEmpty().WithMessage("Ilce alanı bos gecilemez");
            RuleFor(x => x.AddressDetail).NotEmpty().WithMessage("Adres alanı bos gecilemez");
            RuleForEach(x => x.OrderDetails).ChildRules(child =>
            {
                //child.RuleFor(x => x.OrderId).NotEqual(0).WithMessage("Order Id alanı bos gecilemez");
                child.RuleFor(x => x.ProductInStockId).NotEqual(0).WithMessage("Supplier Product Id alanı bos gecilemez");
                child.RuleFor(x => x.Amount).NotEqual(0).WithMessage("Amount alanı bos gecilemez");
            });

        }
    }
}
