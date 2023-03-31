using E_Commerce.Dtos.SiteOptionDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.SiteOptionValidation
{
    public class SiteOptionCreateValidatior : AbstractValidator<SiteOptionCreateDto>
    {
        public SiteOptionCreateValidatior()
        {
            RuleFor(x=>x.Email).NotEmpty(); //TODO tobe continue
        }
    }
}
