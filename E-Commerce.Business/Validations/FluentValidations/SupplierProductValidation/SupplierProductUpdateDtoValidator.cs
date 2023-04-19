using E_Commerce.Dtos.SupplierProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.SupplierProductValidation
{
    public class SupplierProductUpdateDtoValidator : AbstractValidator<SupplierProductUpdateDto>
    {
        public SupplierProductUpdateDtoValidator()
        {
            RuleFor(x => x.UnitPrice).NotEqual(0);
        }
    }
}
