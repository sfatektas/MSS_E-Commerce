using E_Commerce.Dtos.ProductDtos;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.ProductValidation
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
    }
}
