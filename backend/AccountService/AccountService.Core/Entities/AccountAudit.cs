
namespace AccountService.Core.Entities;
public partial class AccountAudit
{
    public long AuditId { get; set; }

    public Guid AccountId { get; set; }

    public string Action { get; set; } = null!;

    public string? Payload { get; set; }

    public Guid? PerformedBy { get; set; }

    public DateTime PerformedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
