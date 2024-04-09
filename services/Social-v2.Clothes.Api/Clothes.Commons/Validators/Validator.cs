using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Validators
{

    public static class Validator
    {
        public static ValidationResult Validate<TValidator, TModel>(TModel model) where TValidator : AbstractValidator<TModel>
        {
            TValidator validator = (TValidator) Activator.CreateInstance(typeof(TValidator));
            return validator.Validate(model);
        }
    }

}
