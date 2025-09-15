using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Infrastructure.Persistence;
using Microsoft.Identity.Client;

namespace AccountService.Infrastructure.Repositories
{
    internal class AccountAuditRepository : IAccountAuditRepository
    {
        public readonly AccountServiceDbContext _context;
        public AccountAuditRepository(AccountServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<long> AddAuditLogAsync(AccountAudit audit, CancellationToken cancellationToken)
        {
            await _context.AccountAudits.AddAsync(audit,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return audit.AuditId;
        }

        public Task<List<AccountAudit>> GetAuditLogsByAccountId(Guid accountId, CancellationToken cancellationToken)
        {
            var result = _context.AccountAudits.Where(x=>x.AccountId == accountId).ToList();
            return Task.FromResult(result);
        }

        public Task<List<AccountAudit>> GetAuditLogsByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var result = _context.AccountAudits.Where(x => x.PerformedBy == userId).ToList();
            return Task.FromResult(result);
        }
    }
}
