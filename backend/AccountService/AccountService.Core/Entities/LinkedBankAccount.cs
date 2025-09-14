
namespace AccountService.Core.Entities;

public partial class LinkedBankAccount
{
    public Guid IntegrationId { get; set; }

    public Guid AccountId { get; set; }

    public string Provider { get; set; } = null!;

    public string? ProviderAccountId { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? LastSyncAt { get; set; }

    public string? Metadata { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
