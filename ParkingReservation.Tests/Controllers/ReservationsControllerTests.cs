using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Application.Services;
using ParkingReservation.Controllers;
using Xunit;

namespace ParkingReservation.Tests.Controllers;

public class ReservationsControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkResult()
    {
        // Arrange
        Mock<IReservationService> mockService = new Mock<IReservationService>();
        mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<ReservationDto>());

        ReservationsController controller = new ReservationsController(mockService.Object);

        // Act
        ActionResult<List<ReservationDto>> actionResult = await controller.GetAll();

        // Assert
        OkObjectResult? result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task Create_ValidRequest_ReturnsCreatedAtAction()
    {
        // Arrange
        Mock<IReservationService> mockService = new Mock<IReservationService>();
        CreateReservationDto createDto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt",
            StartTime = DateTimeOffset.UtcNow,
            EndTime = DateTimeOffset.UtcNow.AddHours(1)
        };
        ReservationDto createdDto = new ReservationDto { Id = 1, ParkingSpaceId = 1, ApplicantName = "Teszt" };

        mockService.Setup(s => s.CreateAsync(createDto)).ReturnsAsync(createdDto);

        ReservationsController controller = new ReservationsController(mockService.Object);

        // Act
        ActionResult<ReservationDto> actionResult = await controller.Create(createDto);

        // Assert
        CreatedAtActionResult? result = actionResult.Result as CreatedAtActionResult;
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
        Assert.Equal(createdDto, result.Value);
    }

    [Fact]
    public async Task Create_SpaceNotFound_ReturnsBadRequest()
    {
        // Arrange
        Mock<IReservationService> mockService = new Mock<IReservationService>();
        CreateReservationDto createDto = new CreateReservationDto
        {
            ParkingSpaceId = 999,
            ApplicantName = "Teszt",
            StartTime = DateTimeOffset.UtcNow,
            EndTime = DateTimeOffset.UtcNow.AddHours(1)
        };

        // A szerviz null-t ad vissza, ha nem létezik a parkoló
        mockService.Setup(s => s.CreateAsync(createDto)).ReturnsAsync((ReservationDto?)null);

        ReservationsController controller = new ReservationsController(mockService.Object);

        // Act
        ActionResult<ReservationDto> actionResult = await controller.Create(createDto);

        // Assert
        BadRequestObjectResult? result = actionResult.Result as BadRequestObjectResult;
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task Create_Conflict_ReturnsConflict()
    {
        // Arrange
        Mock<IReservationService> mockService = new Mock<IReservationService>();
        CreateReservationDto createDto = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Teszt",
            StartTime = DateTimeOffset.UtcNow,
            EndTime = DateTimeOffset.UtcNow.AddHours(1)
        };

        // A szerviz kivételt dob ütközés esetén
        mockService.Setup(s => s.CreateAsync(createDto)).ThrowsAsync(new InvalidOperationException("Ütközés"));

        ReservationsController controller = new ReservationsController(mockService.Object);

        // Act
        ActionResult<ReservationDto> actionResult = await controller.Create(createDto);

        // Assert
        ConflictObjectResult? result = actionResult.Result as ConflictObjectResult;
        Assert.NotNull(result);
        Assert.Equal(409, result.StatusCode);
    }
}