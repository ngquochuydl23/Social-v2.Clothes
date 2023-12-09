using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
