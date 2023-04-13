using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Presentation.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class BrandCreateModelValidator : AbstractValidator<BrandCreateModel>
    {
        public BrandCreateModelValidator()
        {
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Marka adı boş olamaz.").WithName("Marka Adı");
            RuleFor(x => x.File).NotNull().SetValidator(new FileValidator());
        }
    }
}
