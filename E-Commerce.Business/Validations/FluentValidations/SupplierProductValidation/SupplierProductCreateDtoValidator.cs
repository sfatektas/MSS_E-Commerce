using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.SupplierProductValidation
{
    public class SupplierProductCreateDtoValidator : AbstractValidator<SupplierProductCreateDto>
    {
        public SupplierProductCreateDtoValidator()
        {
            RuleFor(x => x.UnitPrice).NotEqual(0);
        }
    }
}
