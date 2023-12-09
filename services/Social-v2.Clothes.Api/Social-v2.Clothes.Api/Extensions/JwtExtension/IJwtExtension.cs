namespace Social_v2.Clothes.Api.Extensions.JwtHelpers
{
  public interface IJwtExtension
  {
    string GenerateToken(long id, string role);
  }
}
