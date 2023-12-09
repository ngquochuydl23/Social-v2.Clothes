using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Dtos
{
    public class SignUpRequestDto
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
