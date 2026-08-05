using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Application.Services;
using ParkingReservation.Domain.Entities;
using ParkingReservation.Domain.Enums;
using ParkingReservation.Infrastructure.Data;
using Xunit;

namespace ParkingReservation.Tests.Services;

public class ReservationServiceTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateAsync_ValidStandardSpace_ReturnsDto()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.Add(new ParkingSpace { Id = 1, Type = ParkingSpaceType.Standard });
        await context.SaveChangesAsync();

        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt Elek",
            StartTime = DateTimeOffset.UtcNow.AddDays(1),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2)
        };

        // Act
        ReservationDto? result = await service.CreateAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Teszt Elek", result.ApplicantName);
        Assert.Equal(1, result.ParkingSpaceId);
    }

    [Fact]
    public async Task CreateAsync_AccessibleSpaceWithPermit_ReturnsDto()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.Add(new ParkingSpace { Id = 1, Type = ParkingSpaceType.Accessible });
        await context.SaveChangesAsync();

        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt Elek",
            StartTime = DateTimeOffset.UtcNow.AddDays(1),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2),
            HasSpecialPermit = true
        };

        // Act
        ReservationDto? result = await service.CreateAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.ParkingSpaceId);
    }

    [Fact]
    public async Task CreateAsync_ElectricSpaceWithVehicle_ReturnsDto()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.Add(new ParkingSpace { Id = 1, Type = ParkingSpaceType.Electric });
        await context.SaveChangesAsync();

        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt Elek",
            StartTime = DateTimeOffset.UtcNow.AddDays(1),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2),
            HasElectricVehicle = true
        };

        // Act
        ReservationDto? result = await service.CreateAsync(dto);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task CreateAsync_SpaceNotFound_ReturnsNull()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 999, // Nem létező ID
            ApplicantName = "Teszt Elek",
            StartTime = DateTimeOffset.UtcNow.AddDays(1),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2)
        };

        // Act
        ReservationDto? result = await service.CreateAsync(dto);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_AccessibleSpaceWithoutPermit_ThrowsInvalidOperationException()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.Add(new ParkingSpace { Id = 1, Type = ParkingSpaceType.Accessible });
        await context.SaveChangesAsync();

        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt Elek",
            StartTime = DateTimeOffset.UtcNow.AddDays(1),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2),
            HasSpecialPermit = false // Hiányzó engedély
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateAsync(dto));
    }

    [Fact]
    public async Task CreateAsync_ElectricSpaceWithoutVehicle_ThrowsInvalidOperationException()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.Add(new ParkingSpace { Id = 1, Type = ParkingSpaceType.Electric });
        await context.SaveChangesAsync();

        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt Elek",
            StartTime = DateTimeOffset.UtcNow.AddDays(1),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2),
            HasElectricVehicle = false // Hiányzó EV jelzés
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateAsync(dto));
    }

    [Fact]
    public async Task CreateAsync_OverlappingTime_ThrowsInvalidOperationException()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.Add(new ParkingSpace { Id = 1, Type = ParkingSpaceType.Standard });
        context.Reservations.Add(new Reservation
        {
            Id = 1,
            ParkingSpaceId = 1,
            ApplicantName = "Korábbi Foglaló",
            StartTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(10),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(12)
        });
        await context.SaveChangesAsync();

        ReservationService service = new ReservationService(context);
        CreateReservationDto dto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Új Foglaló",
            // Ütközik a korábbival (11:00 - 13:00)
            StartTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(11),
            EndTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(13)
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateAsync(dto));
    }
}