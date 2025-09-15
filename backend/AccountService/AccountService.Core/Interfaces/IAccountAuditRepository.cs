using AccountService.Core.Entities;

namespace AccountService.Core.Interfaces
{
    public interface IAccountAuditRepository
    {
        Task<long> AddAuditLogAsync(AccountAudit audit, CancellationToken cancellationToken);

        Task<List<AccountAudit>> GetAuditLogsByUserId(Guid userId, CancellationToken cancellationToken);
        Task<List<AccountAudit>> GetAuditLogsByAccountId(Guid accountId, CancellationToken cancellationToken);
    }
}
