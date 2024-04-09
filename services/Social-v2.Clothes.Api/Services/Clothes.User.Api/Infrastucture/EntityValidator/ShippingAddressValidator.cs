using Clothes.User.Api.Infrastucture.Entities.ShippingAddresses;
using FluentValidation;

namespace Clothes.User.Api.Infrastucture.EntityValidator
{
    public class ShippingAddressValidator : AbstractValidator<ShippingAddressEntity>
    {
        public ShippingAddressValidator() 
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x=>x.PhoneNumber).NotEmpty().Matches("^(032|033|034|035|036|037|038|039|096|097|098|086|083|084|085|081|082|088|091|094|070|079|077|076|078|090|093|089|056|058|092|059|099)[0-9]{7}$");
            RuleFor(x => x.District).NotEmpty();
            RuleFor(x=>x.ProvinceOrCity).NotEmpty();
            RuleFor(x => x.IsDefaultAddress).Equal(false);
            RuleFor(x=>x.AddressDetail).NotEmpty();
            RuleFor(x => x.WardOrCommune).NotEmpty();
        }
    }
}
