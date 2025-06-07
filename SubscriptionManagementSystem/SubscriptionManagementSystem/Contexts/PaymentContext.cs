using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Models;
namespace SubscriptionManagementSystem.Contexts;

public partial class PaymentContext : DbContext
{
    public PaymentContext(DbContextOptions<PaymentContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Payment> Payment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s27804");

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasNoKey();
            
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdSubscription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdClient)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdPayment).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}