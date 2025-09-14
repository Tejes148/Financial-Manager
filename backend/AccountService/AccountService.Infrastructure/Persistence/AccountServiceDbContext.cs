using System;
using Microsoft.EntityFrameworkCore;
using AccountService.Core.Entities;

namespace AccountService.Infrastructure.Persistence;

public partial class AccountServiceDbContext : DbContext
{
    public AccountServiceDbContext()
    {
    }

    public AccountServiceDbContext(DbContextOptions<AccountServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountAudit> AccountAudits { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<LinkedBankAccount> LinkedBankAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AccountServiceDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5A6888ACB01");

            entity.HasIndex(e => e.ExternalAccountId, "IX_Accounts_ExternalAccountId");

            entity.HasIndex(e => e.UserId, "IX_Accounts_UserId");

            entity.Property(e => e.AccountId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AccountType).HasMaxLength(50);
            entity.Property(e => e.AvailableBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("INR")
                .IsFixedLength();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ExternalAccountId).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Provider).HasMaxLength(100);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<AccountAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AccountA__A17F23984E23768C");

            entity.ToTable("AccountAudit");

            entity.HasIndex(e => e.AccountId, "IX_AccountAudit_AccountId");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.PerformedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountAudits)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountAudit_Accounts");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.TypeCode).HasName("PK__AccountT__3E1CDC7D837E377F");

            entity.Property(e => e.TypeCode).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<LinkedBankAccount>(entity =>
        {
            entity.HasKey(e => e.IntegrationId).HasName("PK__LinkedBa__D89568351D1C100C");

            entity.Property(e => e.IntegrationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Provider).HasMaxLength(100);
            entity.Property(e => e.ProviderAccountId).HasMaxLength(200);

            entity.HasOne(d => d.Account).WithMany(p => p.LinkedBankAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkedBankAccounts_Accounts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
