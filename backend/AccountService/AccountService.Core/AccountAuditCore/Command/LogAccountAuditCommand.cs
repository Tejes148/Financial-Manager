using MediatR;

namespace AccountService.Core.AccountAuditCore.Command
{
    public class LogAccountAuditCommand : IRequest<long>
    {
        public Guid AccountId { get; set; }
        public Guid? PerformedBy { get; set; }
        public string Action { get; set; }
        public string? Payload { get; set; }

        public LogAccountAuditCommand(Guid accountId, Guid? performedBy, string action, string? payload)
        {
            AccountId = accountId;
            PerformedBy = performedBy;
            Action = action;
            Payload = payload;
        }
    }
}
