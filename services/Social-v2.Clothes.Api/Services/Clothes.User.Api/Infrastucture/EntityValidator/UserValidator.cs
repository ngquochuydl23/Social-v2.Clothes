using Clothes.User.Api.Infrastucture.Entities.Users;
using FluentValidation;

namespace Clothes.User.Api.Infrastucture.EntityValidator
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator() 
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(20); 
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches("^(032|033|034|035|036|037|038|039|096|097|098|086|083|084|085|081|082|088|091|094|070|079|077|076|078|090|093|089|056|058|092|059|099)[0-9]{7}$");
            RuleFor(x => x.Email).NotEmpty().Matches("^([\\w]*[\\w\\.]*(?!\\.)@gmail.com)");
            RuleFor(x => x.Password).NotEmpty().Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("Minimum eight characters, at least one letter, one number and one special character:");
        }
    }
}
