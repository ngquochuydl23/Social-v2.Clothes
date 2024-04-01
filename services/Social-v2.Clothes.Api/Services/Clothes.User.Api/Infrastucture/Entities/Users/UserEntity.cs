using Clothes.Commons.Seedworks;

namespace Clothes.User.Api.Infrastucture.Entities.Users
{
    public class UserEntity: Entity<long>
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
