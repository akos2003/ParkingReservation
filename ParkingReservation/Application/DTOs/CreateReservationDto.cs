using System;

namespace ParkingReservation.Application.DTOs;

public class CreateReservationDto
{
    public int ParkingSpaceId { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public required string ApplicantName { get; set; }

    // Mozgássérült jogosultság ellenőrzésére
    public bool HasSpecialPermit { get; set; }

    // Új mező az elektromos járművek ellenőrzésére
    public bool HasElectricVehicle { get; set; }
}