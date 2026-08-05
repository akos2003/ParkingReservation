using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Domain.Entities;
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
        bool spaceExists = await _context.ParkingSpaces.AnyAsync(p => p.Id == dto.ParkingSpaceId);
        if (!spaceExists)
        {
            return null;
        }

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