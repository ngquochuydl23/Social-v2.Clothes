using Social_v2.Clothes.Api.Dtos.Users;

namespace Social_v2.Clothes.Api.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }

        public UserDto User { get; set; }

        public LoginResponseDto(string token, UserDto user)
        {
            Token = token;
            User = user;
        }
    }
}
