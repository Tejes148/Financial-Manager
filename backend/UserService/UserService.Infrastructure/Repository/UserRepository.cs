using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;
using UserService.Core.Interfaces;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure.Repository
{ 
public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddUserAsync(User user) // Fix: Change return type to Guid
        {
            try
            {
                var entityEntry = _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return entityEntry.Entity.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var userData = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return userData != null;
        }
    }
}