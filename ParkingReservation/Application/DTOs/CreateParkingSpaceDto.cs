using ParkingReservation.Domain.Enums;

namespace ParkingReservation.Application.DTOs;

public class CreateParkingSpaceDto
{
    public ParkingSpaceType Type { get; set; }
}