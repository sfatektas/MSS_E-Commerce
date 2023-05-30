using E_Commerce.Dtos.CustomerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_Commerce.Business.Validations.FluentValidations.CustomerValidation
{
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator()
        {
            RuleFor(x => x.GenderId).NotEqual(0).WithMessage("Cinsiyet Seçimi Zorunludur.");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FirstName).NotNull().MinimumLength(3);
            RuleFor(x=>x.LastName).NotNull().MinimumLength(3);
            RuleFor(p => p.PhoneNumber)
              .NotEmpty()
              .NotNull().WithMessage("Phone Number is required.")
              .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
              .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
              .Matches(new Regex(@"^[0-9]*$")).WithMessage("Telefon Numarası formatında olmalı.");
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirm).WithMessage("Şifreler birbiri ile uyuşmuyor.");
        }
    }
}
