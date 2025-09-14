using AccountService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Infrastructure.Repositories
{
    internal class AccountAuditRepository
    {
        public readonly AccountServiceDbContext _context;
        public AccountAuditRepository(AccountServiceDbContext context)
        {
            _context = context;
        }

    }
}
