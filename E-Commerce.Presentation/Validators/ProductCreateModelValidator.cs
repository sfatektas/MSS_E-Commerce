using E_Commerce.Presentation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class ProductCreateModelValidator : AbstractValidator<ProductCreateModel>
    {
        public ProductCreateModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x=>x.Detail).NotEmpty().WithMessage("Ürün detayı boş olamaz.");
            RuleFor(x=>x.BrandId).NotEqual(0).WithMessage("Ürünün markası doldurulması zorunludur.");
            RuleFor(x=>x.CategoryId).NotEqual(0).WithMessage("Ürünün kategorisi doldurulması zorunludur.");
            RuleFor(x=>x.SizeTypeId).NotEqual(0).WithMessage("Ürünün bedeni doldurulması zorunludur.");
            RuleFor(x=>x.File).SetValidator(new FileValidator());   
        }
    }
}
