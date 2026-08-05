using ParkingReservation.Domain.Enums;
using ParkingReservation.Domain.Entities;
using System.Collections.Generic;

namespace ParkingReservation.Domain.Entities;

public class ParkingSpace
{
    public int Id { get; init; }
    public ParkingSpaceType Type { get; set; }

    // Navigációs tulajdonság a foglalások eléréséhez
    // Kezdeti érték adása megakadályozza a NullReferenceException-t
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}