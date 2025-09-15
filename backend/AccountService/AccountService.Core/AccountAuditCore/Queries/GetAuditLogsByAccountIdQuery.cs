using AccountService.Core.Entities;
using MediatR;

namespace AccountService.Core.AccountAuditCore.Queries
{
    public class GetAuditLogsByAccountIdQuery : IRequest<List<AccountAudit>>
    {
        public Guid AccountId { get; set; }

        public GetAuditLogsByAccountIdQuery(Guid accountId)
        {
             AccountId = accountId;
        }
    }
}
