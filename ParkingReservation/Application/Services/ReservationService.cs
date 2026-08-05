using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Domain.Entities;
using ParkingReservation.Domain.Enums;
using ParkingReservation.Infrastructure.Data;

namespace ParkingReservation.Application.Services;

public class ReservationService : IReservationService
{
    private readonly AppDbContext _context;

    public ReservationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReservationDto>> GetAllAsync()
    {
        List<Reservation> reservations = await _context.Reservations.ToListAsync();
        List<ReservationDto> result = new List<ReservationDto>();

        foreach (Reservation reservation in reservations)
        {
            result.Add(new ReservationDto
            {
                Id = reservation.Id,
                ParkingSpaceId = reservation.ParkingSpaceId,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                ApplicantName = reservation.ApplicantName
            });
        }

        return result;
    }

    public async Task<List<ReservationDto>> GetByParkingSpaceIdAsync(int parkingSpaceId)
    {
        List<Reservation> reservations = await _context.Reservations
            .Where(r => r.ParkingSpaceId == parkingSpaceId)
            .ToListAsync();

        List<ReservationDto> result = new List<ReservationDto>();

        foreach (Reservation reservation in reservations)
        {
            result.Add(new ReservationDto
            {
                Id = reservation.Id,
                ParkingSpaceId = reservation.ParkingSpaceId,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                ApplicantName = reservation.ApplicantName
            });
        }

        return result;
    }

    public async Task<ReservationDto?> CreateAsync(CreateReservationDto dto)
    {
        ParkingSpace? space = await _context.ParkingSpaces.FirstOrDefaultAsync(p => p.Id == dto.ParkingSpaceId);

        if (space == null)
        {
            return null;
        }

        // Mozgássérült jogosultság ellenőrzése
        if (space.Type == ParkingSpaceType.Accessible && dto.HasSpecialPermit == false)
        {
            throw new InvalidOperationException("Mozgássérült parkolóhely foglalásához érvényes engedély szükséges (HasSpecialPermit = true).");
        }

        // --- Új üzleti logika: Elektromos jármű ellenőrzése ---
        if (space.Type == ParkingSpaceType.Electric && dto.HasElectricVehicle == false)
        {
            throw new InvalidOperationException("Elektromos parkolóhely foglalásához elektromos jármű szükséges (HasElectricVehicle = true).");
        }

        // Ütközésvizsgálat
        bool hasConflict = await _context.Reservations
            .AnyAsync(r => r.ParkingSpaceId == dto.ParkingSpaceId &&
                           r.StartTime < dto.EndTime &&
                           dto.StartTime < r.EndTime);

        if (hasConflict)
        {
            throw new InvalidOperationException("A megadott időpontban a parkolóhely már foglalt.");
        }

        Reservation reservation = new Reservation
        {
            ParkingSpaceId = dto.ParkingSpaceId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            ApplicantName = dto.ApplicantName
        };

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        ReservationDto result = new ReservationDto
        {
            Id = reservation.Id,
            ParkingSpaceId = reservation.ParkingSpaceId,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            ApplicantName = reservation.ApplicantName
        };

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Reservation? reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return false;
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return true;
    }
}