using Clothes.Commons.Seedworks;
using Clothes.User.Api.Infrastucture.Entities.ShippingAddresses;
using Clothes.User.Api.Infrastucture.Entities.Wishlists;
using System.Diagnostics.CodeAnalysis;

namespace Clothes.User.Api.Infrastucture.Entities.Users
{
    public class UserEntity: Entity<long>, ILastLogin
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDay { get; set; }

        public Boolean? Gender { get; set; } = false;

        public string Role { get; set; } = "Customer";

        public string? Avatar { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual ICollection<WishlistEntity> Wishlists { get; set; }=new List<WishlistEntity>();

        public virtual ICollection<ShippingAddressEntity> ShippingAddresses { get; set; } = new List<ShippingAddressEntity>();

        public UserEntity() { }

        public UserEntity(string fullName, string phoneNumber, string email, string password, DateTime birthDay, Boolean gender, string role, string avatar, DateTime lastLogin)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            BirthDay = birthDay;
            Gender = gender;
            Role = role;
            Avatar = avatar;
            LastLogin = lastLogin;
        }
    }
}
