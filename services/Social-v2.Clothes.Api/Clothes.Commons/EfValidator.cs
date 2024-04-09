using Clothes.Commons.Exceptions;
using Clothes.Commons.Seedworks;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons
{
    public class EfValidator<TDto, IValid> : IValidator<TDto, IValid> where TDto : class where IValid : AbstractValidator<TDto>
    {
        private readonly IValid _validClass;
        public EfValidator(IValid validClass)
        {
            _validClass=validClass;
        }


        public Boolean Validate(TDto dto)
        {
            ValidationResult results = _validClass.Validate(dto);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new AppException("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                return false;
            }
            return true;
        }
    }
}
