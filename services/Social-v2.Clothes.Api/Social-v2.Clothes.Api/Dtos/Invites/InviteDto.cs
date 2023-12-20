using Social_v2.Clothes.Api.Infrastructure.Entities.Invites;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Invites
{
    public class InviteDto
    {
        public string Email { get; set; }

        public string Role { get; set; } = UserConstants.AdministratorRole;

        public DateTime ExpiresAt { get; set; }
    }
}
