using E_Commerce.Common;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Extenisons
{
    public static class HelperExtensionMethods
    {
        public static List<ValidationError> GetValidationErrors(this ValidationResult result)
        {
            var list = new List<ValidationError>();

            foreach (var error in result.Errors)
            {
                list.Add(new ValidationError (
                    error.ErrorCode, 
                    error.ErrorMessage) );
            }
            return list;
        }
    }
}
