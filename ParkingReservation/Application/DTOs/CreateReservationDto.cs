using System;

namespace ParkingReservation.Application.DTOs;

public class CreateReservationDto
{
    public int ParkingSpaceId { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public required string ApplicantName { get; set; }
}