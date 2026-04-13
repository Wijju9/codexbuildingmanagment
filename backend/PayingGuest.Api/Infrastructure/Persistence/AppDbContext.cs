using Microsoft.EntityFrameworkCore;
using PayingGuest.Api.Domain;

namespace PayingGuest.Api.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<GuestAssignment> GuestAssignments => Set<GuestAssignment>();
    public DbSet<Invoice> Invoices => Set<Invoice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>(entity =>
        {
            entity.Property(x => x.Name).HasMaxLength(120).IsRequired();
            entity.Property(x => x.City).HasMaxLength(80).IsRequired();
            entity.Property(x => x.StateCode).HasMaxLength(2).IsRequired();
            entity.Property(x => x.ZipCode).HasMaxLength(10).IsRequired();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(x => x.RoomNumber).HasMaxLength(20).IsRequired();
            entity.Property(x => x.MonthlyRentUsd).HasPrecision(10, 2);
            entity.HasOne(x => x.Property)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.Property(x => x.FullName).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(180).IsRequired();
            entity.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            entity.HasIndex(x => x.Email).IsUnique();
        });

        modelBuilder.Entity<GuestAssignment>(entity =>
        {
            entity.HasOne(x => x.Guest)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.GuestId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.Room)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(x => x.AmountUsd).HasPrecision(10, 2);
            entity.HasOne(x => x.Guest)
                .WithMany()
                .HasForeignKey(x => x.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
