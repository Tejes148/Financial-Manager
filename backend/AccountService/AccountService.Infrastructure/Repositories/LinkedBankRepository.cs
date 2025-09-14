using AccountService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Infrastructure.Repositories
{
    internal class LinkedBankRepository
    {
        public readonly AccountServiceDbContext _context;
        public LinkedBankRepository(AccountServiceDbContext context)
        {
            _context = context;
        }
    }
}
