using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Invites
{
    public class CreateUserFromInviteDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public int? Gender { get; set; }
    }
}
