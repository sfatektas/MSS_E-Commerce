using E_Commerce.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class SupplierProductUpdateModelValidator : AbstractValidator<SupplierProductUpdateModel>
    {
        public SupplierProductUpdateModelValidator()
        {
            RuleFor(x => x.CustomProductTitle).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEqual(0);
            RuleFor(x => x.SizeId).NotEqual(0);
            RuleFor(x => x.CustomProductDefination).NotEmpty();
            RuleFor(x => x.ColorId).NotEqual(0);
        }
    }
}
