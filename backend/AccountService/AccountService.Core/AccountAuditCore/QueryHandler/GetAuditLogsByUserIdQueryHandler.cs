using AccountService.Core.AccountAuditCore.Command;
using AccountService.Core.AccountAuditCore.Queries;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountAuditCore.QueryHandler
{
        public class GetAuditLogsByUserIdQueryHandler : IRequestHandler<GetAuditLogsByUserIdQuery, List<AccountAudit>>
        {
            private readonly IAccountAuditRepository _repository;

            public GetAuditLogsByUserIdQueryHandler(IAccountAuditRepository repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<List<AccountAudit>> Handle(GetAuditLogsByUserIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetAuditLogsByUserId(request.UserId, cancellationToken);
                return result; // return the generated identity key
            }
        }
}
