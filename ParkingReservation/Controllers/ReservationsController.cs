using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Application.Services;

namespace ParkingReservation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservationDto>>> GetAll()
    {
        List<ReservationDto> reservations = await _reservationService.GetAllAsync();
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<ActionResult<ReservationDto>> Create([FromBody] CreateReservationDto dto)
    {
        try
        {
            ReservationDto? createdReservation = await _reservationService.CreateAsync(dto);
            if (createdReservation == null)
            {
                return BadRequest("A megadott parkolóhely nem létezik.");
            }
            return CreatedAtAction(nameof(GetAll), new { id = createdReservation.Id }, createdReservation);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _reservationService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}