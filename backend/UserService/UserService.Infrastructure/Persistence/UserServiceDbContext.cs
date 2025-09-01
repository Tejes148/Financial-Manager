using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;

namespace UserService.Infrastructure.Persistence;

public partial class UserServiceDbContext : DbContext
{
    public UserServiceDbContext()
    {
    }

    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId).HasName("PK__RefreshT__F5845E392F0B4771");

            entity.HasIndex(e => e.UserId, "IX_RefreshToken_UserId");

            entity.HasIndex(e => e.Token, "UQ__RefreshT__1EB4F817054B51CE").IsUnique();

            entity.Property(e => e.RefreshTokenId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Token).HasMaxLength(200);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RefreshTo__UserI__5070F446");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastLoginAt).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
