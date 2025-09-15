using AccountService.Core.Entities;
using MediatR;

namespace AccountService.Core.AccountAuditCore.Queries
{
    public class GetAuditLogsByUserIdQuery : IRequest<List<AccountAudit>>
    {
        public Guid UserId { get; set; }
        public GetAuditLogsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
