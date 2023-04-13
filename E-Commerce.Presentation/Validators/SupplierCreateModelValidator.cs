using E_Commerce.Presentation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class SupplierCreateModelValidator : AbstractValidator<SupplierCreateModel>
    {
        public SupplierCreateModelValidator()
        {
            RuleFor(x=>x.Username).NotEmpty(); // will add.
            RuleFor(x=>x.CompanyDetail).NotEmpty();
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Matches(x => x.PasswordConfirm).WithMessage("Şifreler birbirleriyle uyuşmuyor lütfen kontrol ediniz."); // todo mus // password ile confirm yapısın eşitlenecek
            RuleFor(x=>x.CompanyDetail).NotEmpty();
            RuleFor(x=>x.PhoneNumber).NotEmpty().Matches("^[0-9]*$").WithMessage("Telefon numarası sadece sayı formatında olmalı."); ;
            RuleFor(x=>x.CompanyDetail).NotEmpty();
            RuleFor(x=>x.File).SetValidator(new FileValidator());
        }
    }
}
