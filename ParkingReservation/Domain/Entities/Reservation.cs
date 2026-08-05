using System;

namespace ParkingReservation.Domain.Entities;

public class Reservation
{
    public int Id { get; init; }

    // Idegen kulcs
    public int ParkingSpaceId { get; set; }

    // Navigációs tulajdonság (lehet null, amíg az EF be nem tölti)
    public ParkingSpace? ParkingSpace { get; set; }

    // DateTimeOffset használata a pontos idő/időzóna miatt
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }

    // A 'required' biztosítja, hogy a példányosításkor meg kell adni a nevet
    public required string ApplicantName { get; set; }
}