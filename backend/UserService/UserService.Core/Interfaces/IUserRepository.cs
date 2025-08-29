using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Entities;

namespace UserService.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> ExistsByEmailAsync(string email);
        public Task<Guid> AddUserAsync(User user);
    }
}
