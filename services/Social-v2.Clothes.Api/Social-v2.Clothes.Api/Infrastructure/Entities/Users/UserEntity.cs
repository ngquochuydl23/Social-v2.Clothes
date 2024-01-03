using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.EmployeeInvitations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Orders;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Users
{
    public class UserEntity : Entity<long>
    {
        [NotNull]
        [MaxLength(UserConstants.UserFullNameMaxLength)]
        public string FullName { get; set; }

        [NotNull]
        [MaxLength(UserConstants.UserPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [NotNull]
        [MaxLength(UserConstants.UserEmailMaxLength)]
        public string Email { get; set; }

        [NotNull]
        [MaxLength(UserConstants.UserHashPassword)]
        public string HashPassword { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime LastLogin { get; set; }

        public int? Gender { get; set; }

        public string? Avatar { get; set; }

        public string Role { get; set; } = UserConstants.CustomerRole;

        public virtual CartEntity? Cart { get; set; }

        public virtual EmployeeInvitationEntity? EmployeeInvitation { get; set; }

        public string? EmployeeStatus { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

        public virtual IEnumerable<DeliveryAddressEntity> DeliveryAddresses { get; set; } = new List<DeliveryAddressEntity>();

        public virtual IEnumerable<WishlistEntity> Wishlists { get; set; } = new List<WishlistEntity>();
    }
}
