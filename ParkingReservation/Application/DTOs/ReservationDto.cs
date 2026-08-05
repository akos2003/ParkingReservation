using System;

namespace ParkingReservation.Application.DTOs;

public class ReservationDto
{
    public int Id { get; init; }
    public int ParkingSpaceId { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public string ApplicantName { get; set; } = string.Empty;
}