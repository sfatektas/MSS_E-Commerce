using E_Commerce.Presentation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class SupplierProductCreateModelValidator : AbstractValidator<SupplierProductCreateModel>
    {
        public SupplierProductCreateModelValidator()
        {
            RuleFor(x => x.CustomProductTitle).MinimumLength(5).WithMessage("Başlık alanı minimum 5 karakter olabilir.");
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.SupplierId).NotEqual(0);
            RuleFor(x => x.ProductId).NotEqual(0);
            RuleFor(x => x.ColorId).NotEqual(0);
            RuleForEach(x=>x.Files).SetValidator(new FileValidator());
        }
    }
}
