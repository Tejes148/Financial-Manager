using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Repositories
{
    internal class LinkedBankRepository : ILinkedBankRepository
    {
        private readonly AccountServiceDbContext _context;
        public LinkedBankRepository(AccountServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> LinkedBankAccount(LinkedBankAccount linkedBankAccount, CancellationToken cancellationToken)
        {
            await _context.LinkedBankAccounts.AddAsync(linkedBankAccount, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return linkedBankAccount.IntegrationId;
        }

        public async Task<Guid> UnLinkedBankAccount(Guid linkedBankAccountID, CancellationToken cancellationToken)
        {
            var result = await _context.LinkedBankAccounts.Where(x=>x.AccountId == linkedBankAccountID).FirstOrDefaultAsync(cancellationToken);

            var row =  _context.LinkedBankAccounts.Remove(result);
            await _context.SaveChangesAsync(cancellationToken);
            return row.Entity.IntegrationId;
        }

        public async Task<LinkedBankAccount> GetLinkedBankByAccountId(Guid linkedBankAccountID, CancellationToken cancellationToken)
        {
            var result = await _context.LinkedBankAccounts.Where(x=>x.AccountId == linkedBankAccountID).FirstOrDefaultAsync(cancellationToken);

            return result;
        }



    }
}
