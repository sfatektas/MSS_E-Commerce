using E_Commerce.Presentation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class SliderItemCreateModelValidator : AbstractValidator<SliderItemCreateModel>
    {
        public SliderItemCreateModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title boş olamaz.");
            RuleFor(x => x.SubTitle).NotEmpty();
            RuleFor(x => x.SliderId).NotEmpty();
            RuleFor(x => x.ButtonLink).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.File).NotNull().SetValidator(new FileValidator());
        }
    }
}
