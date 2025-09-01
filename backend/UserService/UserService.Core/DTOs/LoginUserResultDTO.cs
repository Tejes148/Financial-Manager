
namespace UserService.Core.DTOs
{
    public class LoginUserResultDTO
    {
        public bool Success { get; set; }
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? FailureMessage { get; set; }
    }
}
