using E_Commerce.Dtos.BrandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.BrandValidation
{
    public class BrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
    {
        public BrandCreateDtoValidator()
        {
            RuleFor(x=>x.Defination).NotEmpty();
            RuleFor(x=>x.ImageUrl).NotEmpty();
        }
    }
}
