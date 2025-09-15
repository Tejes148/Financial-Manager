namespace AccountService.Core.Entities
{

    public class Account
    {
        public Guid AccountId { get; set; }

        public Guid UserId { get; set; }

        public string AccountType { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public string? Provider { get; set; }

        public string? ExternalAccountId { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal? AvailableBalance { get; set; }

        public byte Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual ICollection<AccountAudit> AccountAudits { get; set; } = new List<AccountAudit>();

        public virtual ICollection<LinkedBankAccount> LinkedBankAccounts { get; set; } = new List<LinkedBankAccount>();

        public static Account Empty()
        {
            throw new NotImplementedException();
        }
    }
}