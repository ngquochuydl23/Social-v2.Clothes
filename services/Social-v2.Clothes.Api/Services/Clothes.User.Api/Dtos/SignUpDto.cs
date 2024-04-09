using Clothes.User.Api.Infrastucture.EntityValidator;
using System.ComponentModel.DataAnnotations;

namespace Clothes.User.Api.Dtos
{

    public class SignUpDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public Boolean Gender { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
