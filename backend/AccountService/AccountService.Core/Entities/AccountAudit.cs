
namespace AccountService.Core.Entities;
public partial class AccountAudit
{
    public long AuditId { get; set; }              // Primary Key
    public Guid AccountId { get; set; }            // FK to Account
    public string Action { get; set; } = null!;    // e.g. Created, Updated, Deleted
    public string? Payload { get; set; }           // JSON or details of change
    public Guid? PerformedBy { get; set; }         // UserId (nullable if system-generated)
    public DateTime PerformedAt { get; set; }      // UTC timestamp
    public virtual Account Account { get; set; } = null!;
}
