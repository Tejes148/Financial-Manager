using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Repositories
{
    internal class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly AccountServiceDbContext _context;

        public AccountTypeRepository(AccountServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<AccountType> AddAccountTypeAsync(AccountType accountType, CancellationToken cancellationToken = default)
        {
            var result = await _context.AccountTypes.AddAsync(accountType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }

        public async Task<bool> DeleteAccountTypeAsync(string typeCode, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AccountTypes.SingleOrDefaultAsync(x => x.TypeCode == typeCode, cancellationToken);

            if (entity is null)
                return false;

            _context.AccountTypes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<AccountType?> GetAccountTypeByCodeAsync(string typeCode, CancellationToken cancellationToken = default)
        {
            return await _context.AccountTypes.FirstOrDefaultAsync(x => x.TypeCode == typeCode, cancellationToken);
        }

        public async Task<IEnumerable<AccountType>> GetAllAccountTypesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.AccountTypes.ToListAsync(cancellationToken);
        }

        public async Task<AccountType> UpdateAccountTypeAsync(AccountType accountType, CancellationToken cancellationToken = default)
        {
            var entity = _context.AccountTypes.Update(accountType);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Entity;
        }
    }
}
