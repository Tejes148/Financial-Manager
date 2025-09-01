
using UserService.Core.Entities;

namespace UserService.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<Guid> AddUserAsync(User user, CancellationToken cancellationToken);
        public Task SaveRefreshTokenAsync(Guid userId, string refreshToken, DateTime expiry, CancellationToken cancellationToken);
        public Task UpdateLastLoginAsync(Guid userId, DateTime loginTime, CancellationToken cancellationToken);
    }
}
