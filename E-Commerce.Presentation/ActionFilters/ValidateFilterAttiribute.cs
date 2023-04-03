using E_Commerce.Business.Extenisons;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.ActionFilters
{
    // Açıklama =>  Generic bir dto tipi alarak o tipe sahip validate işlemlerini yapan bir action filter
    public class ValidateFilterAttiribute<ValidateDto> : IAsyncActionFilter where ValidateDto : class
    {
        readonly IValidator<ValidateDto> validator;

        public ValidateFilterAttiribute(IValidator<ValidateDto> validator)
        {
            this.validator = validator;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            // Dto or model anything..
            var param  = context.ActionArguments
                .SingleOrDefault(p => p.Value.ToString().Contains("Dto") || p.Value.ToString().Contains("Model")).Value;

            ValidateDto dto = param as ValidateDto;
            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. " +
                    $"Controller : {controller} " +
                    $"Action :  {action}");
                return; // 400
            }
            var result = await validator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await next();
            }
            foreach (var error in result.GetValidationErrors())
            {
                context.ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
            }
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}
