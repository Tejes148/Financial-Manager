using AccountService.Core.AccountAuditCore.Queries;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountAuditCore.QueryHandler
{
    public class GetAuditLogsByAccountIdQueryHandler : IRequestHandler<GetAuditLogsByAccountIdQuery, List<AccountAudit>>
    {
        private readonly IAccountAuditRepository _repository;

        public GetAuditLogsByAccountIdQueryHandler(IAccountAuditRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<AccountAudit>> Handle(GetAuditLogsByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAuditLogsByAccountId(request.AccountId, cancellationToken);
            return result; 
        }
    }
}
