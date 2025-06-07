using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Models;
namespace SubscriptionManagementSystem.Contexts;

public partial class SaleContext : DbContext
{
    public SaleContext(DbContextOptions<SaleContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Sale> Sale { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s27804");

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasNoKey();
            
            entity.Property(e => e.IdClient)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdSubscription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdSale).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}