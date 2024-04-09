using Clothes.User.Api.Dtos;
using FluentValidation;

namespace Clothes.User.Api.Validators
{
    public class SignUpValidator : AbstractValidator<SignUpDto>
    {
        public SignUpValidator() 
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Length(10)
                .WithMessage("Số điện thoại phải đúng 10 kí tự")
                .Matches(@"^(032|033|034|035|036|037|038|039|096|097|098|086|083|084|085|081|082|088|091|094|070|079|077|076|078|090|093|089|056|058|092|059|099)[0-9]{7}$")
                .WithMessage("Số điện thoại phải đúng định dạng");

        }
    }
}
