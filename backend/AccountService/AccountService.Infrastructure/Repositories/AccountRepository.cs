using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        public readonly AccountServiceDbContext _context;
        public AccountRepository(AccountServiceDbContext context)
        {
            _context = context;
        }

        // A/c Create
        public async Task<Guid> AddAccountAsync(Account account, CancellationToken cancellationToken)
        {
            await _context.Accounts.AddAsync(account,cancellationToken);
            await _context.SaveChangesAsync();
            return account.AccountId;
        }

        // Get A/c by A/c Number
        public async Task<Account> GetAccountByAccountNumberAsync(string AccountNumber, CancellationToken cancellationToken)
        {
            var result = await _context.Accounts.Where(a => a.Name == AccountNumber).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        // Get All A/cs
        public async Task<IEnumerable<Account>> GetAllAccountsAsync(Guid userId, CancellationToken cancellation)
        {
            return await _context.Accounts.Where(x =>  x.UserId == userId).ToListAsync(cancellation);
        }

        // Update A/c
        public async Task<Guid> UpdateAccountAsync(Account account, CancellationToken cancellationToken)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync(cancellationToken);
            return account.AccountId;
        }

        // Delete A/c
        public async Task<bool> DeleteAccountAsync(string AccountNumber, CancellationToken cancellationToken)
        {
          
            var account = await GetAccountByAccountNumberAsync(AccountNumber, cancellationToken);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
