using SubscriptionManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace SubscriptionManagementSystem.Contexts;

public partial class ClientContext : DbContext
{
    public ClientContext(DbContextOptions<ClientContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Client> Client { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s27804");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdClient).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}