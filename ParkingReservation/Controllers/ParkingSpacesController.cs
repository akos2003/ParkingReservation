using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Application.Services;

namespace ParkingReservation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingSpacesController : ControllerBase
{
    private readonly IParkingSpaceService _parkingSpaceService;
    private readonly IReservationService _reservationService;

    public ParkingSpacesController(
        IParkingSpaceService parkingSpaceService,
        IReservationService reservationService)
    {
        _parkingSpaceService = parkingSpaceService;
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ParkingSpaceDto>>> GetAll()
    {
        List<ParkingSpaceDto> spaces = await _parkingSpaceService.GetAllAsync();
        return Ok(spaces);
    }

    [HttpPost]
    public async Task<ActionResult<ParkingSpaceDto>> Create([FromBody] CreateParkingSpaceDto dto)
    {
        ParkingSpaceDto createdSpace = await _parkingSpaceService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = createdSpace.Id }, createdSpace);
    }

    // Új végpont: adott parkolóhelyhez tartozó foglalások lekérdezése
    [HttpGet("{id}/reservations")]
    public async Task<ActionResult<List<ReservationDto>>> GetReservationsByParkingSpace(int id)
    {
        List<ParkingSpaceDto> spaces = await _parkingSpaceService.GetAllAsync();
        bool spaceExists = false;

        foreach (ParkingSpaceDto space in spaces)
        {
            if (space.Id == id)
            {
                spaceExists = true;
                break;
            }
        }

        if (!spaceExists)
        {
            return NotFound("A megadott parkolóhely nem létezik.");
        }

        List<ReservationDto> reservations = await _reservationService.GetByParkingSpaceIdAsync(id);
        return Ok(reservations);
    }
}