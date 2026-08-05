using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Application.Services;
using ParkingReservation.Domain.Entities;
using ParkingReservation.Domain.Enums;
using ParkingReservation.Infrastructure.Data;
using Xunit;

namespace ParkingReservation.Tests.Services;

public class ParkingSpaceServiceTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllSpaces()
    {
        // Arrange
        AppDbContext context = GetInMemoryDbContext();
        context.ParkingSpaces.AddRange(
            new ParkingSpace { Id = 1, Type = ParkingSpaceType.Standard },
            new ParkingSpace { Id = 2, Type = ParkingSpaceType.Accessible }
        );
        await context.SaveChangesAsync();

        ParkingSpaceService service = new ParkingSpaceService(context);

        // Act
        List<ParkingSpaceDto> result = await service.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }

    
}