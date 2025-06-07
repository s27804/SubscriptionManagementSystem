using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Models;
namespace SubscriptionManagementSystem.Contexts;

public partial class DiscountContext : DbContext
{
    public DiscountContext(DbContextOptions<DiscountContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Discount> Discount { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s27804");

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasNoKey();
            
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdSubscription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateFrom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateTo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdDiscount).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}