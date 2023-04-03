using E_Commerce.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations
{
    public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginModelValidator() { 
        RuleFor(x=>x.UserName).NotEmpty();
        RuleFor(x=>x.Password).NotEmpty().MinimumLength(5);
        }
    }
}
