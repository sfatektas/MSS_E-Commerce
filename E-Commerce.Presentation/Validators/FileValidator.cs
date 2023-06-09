﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("Dosya adı boş olamaz");
            RuleFor(x => x.Length).NotEqual(0).WithMessage("Dosya alanı zorunludur.").LessThanOrEqualTo(1000 * 1000 * 10) // 10mb 
                .WithMessage("Dosya boyutu 10MB dan fazla olamaz");

        }
    }
}
