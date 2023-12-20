using System.Security.Claims;

namespace Social_v2.Clothes.Api.Extensions.JwtHelpers
{
    public interface IJwtExtension
    {
        string GenerateToken(long id, string role);

        string GenerateTokenForInvitation(string email, string role);

        IEnumerable<Claim> DecodeToken(string token);
    }
}
