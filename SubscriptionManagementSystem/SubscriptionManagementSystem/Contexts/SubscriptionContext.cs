using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Models;
namespace SubscriptionManagementSystem.Contexts;

public partial class SubscriptionContext : DbContext
{
    public SubscriptionContext(DbContextOptions<SubscriptionContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Subscription> Subscription { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s27804");

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RenewalPeriod)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdSubscription).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}