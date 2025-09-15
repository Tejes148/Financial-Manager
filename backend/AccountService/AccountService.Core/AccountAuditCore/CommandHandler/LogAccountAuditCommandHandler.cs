using AccountService.Core.AccountAuditCore.Command;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountAuditCore.CommandHandler
{
    public class LogAccountAuditCommandHandler : IRequestHandler<LogAccountAuditCommand, long>
    {
        private readonly IAccountAuditRepository _repository;

        public LogAccountAuditCommandHandler(IAccountAuditRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<long> Handle(LogAccountAuditCommand request, CancellationToken cancellationToken)
        {
            var audit = new AccountAudit
            {
                AccountId = request.AccountId,
                Action = request.Action,
                Payload = request.Payload,
                PerformedBy = request.PerformedBy,
                PerformedAt = DateTime.UtcNow
            };

            var result = await _repository.AddAuditLogAsync(audit, cancellationToken);
            return result; 
        }

    }
}
