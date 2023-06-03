using E_Commerce.Presentation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Validators
{
    public class AddBasketCreateModelValidator : AbstractValidator<AddBasketCreateModel>
    {
        public AddBasketCreateModelValidator()
        {
            RuleFor(x=>x.ProductInStockId).NotEqual(0).WithMessage("sepete eklenecek olan Ürünün ıd değeri sıfır olamaz");
            RuleFor(x => x.Amount).NotEqual(0).WithMessage("Minimum 1 ürün ekleyebilirsiniz");
            RuleFor(x => x.Username).NotNull();
        }
    }
}
