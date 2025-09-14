using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Infrastructure.Persistence;

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

        // Get A/c by UserId
        public async Task<Account?> GetAccountByAccountIdAsync(Guid AccountNumber, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Accounts.Where(a => a.AccountId == AccountNumber).FirstOrDefault());
        }

        // Get All A/cs
        public async Task<List<Account>> GetAllAccountsAsync(Guid userId, CancellationToken cancellation)
        {
            return await Task.FromResult(_context.Accounts.ToList());
        }

        // Update A/c
        public async Task<Guid> UpdateAccountAsync(Account account, CancellationToken cancellationToken)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account.AccountId;
        }

        // Delete A/c
        public async Task<Guid> DeleteAccountAsync(Guid accountId, CancellationToken cancellationToken)
        {
          
            var account = await GetAccountByAccountIdAsync(accountId, cancellationToken);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return accountId;
            }
            return Guid.Empty;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
