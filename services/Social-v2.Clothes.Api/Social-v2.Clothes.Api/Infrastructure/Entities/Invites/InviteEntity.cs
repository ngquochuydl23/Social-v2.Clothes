using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Invites
{
    public class InviteEntity : Entity<long>
    {
        [MaxLength(InviteConstants.EmailMaxLength)]
        public string Email { get; set; }

        public string Role { get; set; } = UserConstants.AdministratorRole;

        public string Token { get; set; }

        public bool Accepted { get; set; } = false;

        public DateTime ExpiresAt { get; set; }

        public DateTime AcceptedAt { get; set; }
    }
}
