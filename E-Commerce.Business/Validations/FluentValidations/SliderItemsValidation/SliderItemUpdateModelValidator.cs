using E_Commerce.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.SliderItemsValidation
{
    public class SliderItemUpdateModelValidator : AbstractValidator<SliderItemUpdateModel>
    {
        public SliderItemUpdateModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x=>x.SubTitle).NotEmpty();
            RuleFor(x=>x.ButtonText).NotEmpty();
            RuleFor(x=>x.ButtonLink).NotEmpty();
            RuleFor(x=>x.SliderId).NotEqual(0);
        }
    }
}
