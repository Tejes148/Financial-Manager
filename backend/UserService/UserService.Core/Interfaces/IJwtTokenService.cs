
namespace UserService.Core.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(Guid userId, string email);
        string GenerateRefreshToken();
       // bool ValidateJwtToken(string token, out Guid userId);

    }
}
