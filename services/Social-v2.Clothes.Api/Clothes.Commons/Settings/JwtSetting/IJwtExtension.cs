using System.Security.Claims;

namespace Clothes.Commons.Settings.JwtSetting
{
    public interface IJwtExtension
    {
        string GenerateToken(long id, string role);

        IEnumerable<Claim> DecodeToken(string token);
    }
}
