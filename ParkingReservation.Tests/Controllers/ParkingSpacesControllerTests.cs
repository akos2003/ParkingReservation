using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Application.Services;
using ParkingReservation.Controllers;
using Xunit;

namespace ParkingReservation.Tests.Controllers;

public class ParkingSpacesControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkResult()
    {
        // Arrange
        Mock<IParkingSpaceService> mockParkingService = new Mock<IParkingSpaceService>();
        Mock<IReservationService> mockReservationService = new Mock<IReservationService>();

        mockParkingService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<ParkingSpaceDto>());

        ParkingSpacesController controller = new ParkingSpacesController(
            mockParkingService.Object,
            mockReservationService.Object);

        // Act
        ActionResult<List<ParkingSpaceDto>> actionResult = await controller.GetAll();

        // Assert
        OkObjectResult? result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task GetReservationsByParkingSpace_SpaceExists_ReturnsOk()
    {
        // Arrange
        Mock<IParkingSpaceService> mockParkingService = new Mock<IParkingSpaceService>();
        Mock<IReservationService> mockReservationService = new Mock<IReservationService>();

        List<ParkingSpaceDto> spaces = new List<ParkingSpaceDto>
        {
            new ParkingSpaceDto { Id = 1 }
        };
        List<ReservationDto> reservations = new List<ReservationDto>
        {
            new ReservationDto { Id = 1, ParkingSpaceId = 1, ApplicantName = "Teszt" }
        };

        mockParkingService.Setup(s => s.GetAllAsync()).ReturnsAsync(spaces);
        mockReservationService.Setup(s => s.GetByParkingSpaceIdAsync(1)).ReturnsAsync(reservations);

        ParkingSpacesController controller = new ParkingSpacesController(
            mockParkingService.Object,
            mockReservationService.Object);

        // Act
        ActionResult<List<ReservationDto>> actionResult = await controller.GetReservationsByParkingSpace(1);

        // Assert
        OkObjectResult? result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);

        List<ReservationDto>? returnedReservations = result.Value as List<ReservationDto>;
        Assert.NotNull(returnedReservations);
        Assert.Single(returnedReservations);
    }

    [Fact]
    public async Task GetReservationsByParkingSpace_SpaceNotFound_ReturnsNotFound()
    {
        // Arrange
        Mock<IParkingSpaceService> mockParkingService = new Mock<IParkingSpaceService>();
        Mock<IReservationService> mockReservationService = new Mock<IReservationService>();

        // Üres lista, tehát nincs 1-es ID-jú parkoló
        List<ParkingSpaceDto> spaces = new List<ParkingSpaceDto>();

        mockParkingService.Setup(s => s.GetAllAsync()).ReturnsAsync(spaces);

        ParkingSpacesController controller = new ParkingSpacesController(
            mockParkingService.Object,
            mockReservationService.Object);

        // Act
        ActionResult<List<ReservationDto>> actionResult = await controller.GetReservationsByParkingSpace(1);

        // Assert
        NotFoundObjectResult? result = actionResult.Result as NotFoundObjectResult;
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
    }
}