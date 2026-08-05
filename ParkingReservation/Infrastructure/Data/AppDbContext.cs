using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Domain.Entities;
using ParkingReservation.Domain.Enums;

namespace ParkingReservation.Infrastructure.Data;

public class AppDbContext : DbContext
{
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

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.ParkingSpace)
            .WithMany(p => p.Reservations)
            .HasForeignKey(r => r.ParkingSpaceId)
            .OnDelete(DeleteBehavior.Cascade);

        // --- Adatbázis kezdőadatok generálása (Seeding) ---

        List<ParkingSpace> parkingSpaces = new List<ParkingSpace>();

        // 1-80: Normál parkolóhely
        for (int i = 1; i <= 80; i++)
        {
            parkingSpaces.Add(new ParkingSpace { Id = i, Type = ParkingSpaceType.Standard });
        }

        // 81-90: Mozgássérült parkolóhely
        for (int i = 81; i <= 90; i++)
        {
            parkingSpaces.Add(new ParkingSpace { Id = i, Type = ParkingSpaceType.Accessible });
        }

        // 91-100: Elektromos parkolóhely
        for (int i = 91; i <= 100; i++)
        {
            parkingSpaces.Add(new ParkingSpace { Id = i, Type = ParkingSpaceType.Electric });
        }

        // Parkolóhelyek átadása a HasData-nak
        modelBuilder.Entity<ParkingSpace>().HasData(parkingSpaces);

        List<Reservation> reservations = new List<Reservation>();

        // Egy fix bázisdátum a jövőben, hogy a migráció futtatásakor mindig ugyanazt az eredményt kapjuk
        DateTimeOffset baseDate = DateTimeOffset.Parse("2026-08-10T08:00:00+02:00");

        // 50 darab foglalás generálása
        for (int i = 1; i <= 50; i++)
        {
            // A napokat 0 és 9 között variáljuk, az órákat pedig 0 és 4 között tolásoljuk a bázisdátumhoz képest
            int dayOffset = i % 10;
            int hourOffset = i % 5;

            reservations.Add(new Reservation
            {
                Id = i,
                // Minden foglalás egy külön parkolóhelyre kerül (1-től 50-ig), így biztosan nem lesz ütközés
                ParkingSpaceId = i,
                ApplicantName = "Teszt Felhasználó " + i.ToString(),
                StartTime = baseDate.AddDays(dayOffset).AddHours(hourOffset),
                // Minden foglalás 2 óra hosszúságú
                EndTime = baseDate.AddDays(dayOffset).AddHours(hourOffset + 2)
            });
        }

        // Foglalások átadása a HasData-nak
        modelBuilder.Entity<Reservation>().HasData(reservations);
    }
}