using E_Commerce.Presentation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class SupplierCreateModelValidator : AbstractValidator<SupplierCreateModel>
    {
        public SupplierCreateModelValidator()
        {
            RuleFor(x=>x.Username).NotEmpty(); // will add.
        }
    }
}
