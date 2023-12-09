namespace Social_v2.Clothes.Api.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }

        public long UserId { get; set; }

        public LoginResponseDto(string token, long userId)
        {
            Token = token;
            UserId = userId;
        }
    }
}
