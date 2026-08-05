using ParkingReservation.Domain.Enums;

namespace ParkingReservation.Application.DTOs;

public class ParkingSpaceDto
{
    public int Id { get; init; }
    public ParkingSpaceType Type { get; set; }
}