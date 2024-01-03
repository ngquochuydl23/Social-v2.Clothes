using Social_v2.Clothes.Api.Infrastructure.Entities.Invites;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.EmployeeInvitations
{
    public class EmployeeInvitationEntity : Entity<long>
    {

        public long? EmployeeId { get; set; }

        public UserEntity? Employee { get; set; }

        public string Role { get; set; } = UserConstants.AdministratorRole;

        public string Token { get; set; }

        public bool Accepted { get; set; } = false;

        public DateTime ExpiresAt { get; set; }

        public DateTime ResentAt { get; set; }

        public DateTime AcceptedAt { get; set; }
    }
}
