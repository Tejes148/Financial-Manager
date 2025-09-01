using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;
using UserService.Core.Interfaces;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure.Repository
{ 
public class UserRepository : IUserRepository
    {
        private readonly UserServiceDbContext _context;
        public UserRepository(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddUserAsync(User user, CancellationToken cancellationToken) // Fix: Change return type to Guid
        {
            try
            {
                var entityEntry = _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);
                return entityEntry.Entity.UserId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User?> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var userData = await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
            return userData;
        }

        public async Task SaveRefreshTokenAsync(Guid userId, string refreshToken, DateTime expiry, CancellationToken cancellationToken)
        {
            var token = new RefreshToken
            {
                UserId = userId,
                Token = refreshToken,
                ExpiresAt = expiry,
                CreatedAt = DateTime.UtcNow
            };

             _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task UpdateLastLoginAsync(Guid userId, DateTime loginTime, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(userId,cancellationToken);
            if (user != null)
            {
                user.LastLoginAt = loginTime;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}