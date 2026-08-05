using Microsoft.EntityFrameworkCore;
using ParkingReservation.Domain.Entities;

namespace ParkingReservation.Infrastructure.Data;

public class AppDbContext : DbContext
{
    // A Set<T>() metódussal elkerülhető a nullable figyelmeztetés
    public DbSet<ParkingSpace> ParkingSpaces => Set<ParkingSpace>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ParkingSpace konfigurációk
        modelBuilder.Entity<ParkingSpace>()
            .HasKey(p => p.Id);

        // Reservation konfigurációk és kapcsolatok
        modelBuilder.Entity<Reservation>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Reservation>()
            .Property(r => r.ApplicantName)
            .IsRequired()
            .HasMaxLength(150);

        // 1:N (Egy a többhöz) kapcsolat konfigurálása
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.ParkingSpace)
            .WithMany(p => p.Reservations)
            .HasForeignKey(r => r.ParkingSpaceId)
            .OnDelete(DeleteBehavior.Cascade); // Ha egy parkolóhely törlődik, a hozzá tartozó foglalások is
    }
}