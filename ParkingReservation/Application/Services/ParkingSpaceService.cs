using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Domain.Entities;
using ParkingReservation.Infrastructure.Data;

namespace ParkingReservation.Application.Services;

public class ParkingSpaceService : IParkingSpaceService
{
    private readonly AppDbContext _context;

    public ParkingSpaceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ParkingSpaceDto>> GetAllAsync()
    {
        List<ParkingSpace> spaces = await _context.ParkingSpaces.ToListAsync();
        List<ParkingSpaceDto> result = new List<ParkingSpaceDto>();

        foreach (ParkingSpace space in spaces)
        {
            result.Add(new ParkingSpaceDto
            {
                Id = space.Id,
                Type = space.Type
            });
        }

        return result;
    }

    public async Task<ParkingSpaceDto> CreateAsync(CreateParkingSpaceDto dto)
    {
        ParkingSpace space = new ParkingSpace
        {
            Type = dto.Type
        };

        _context.ParkingSpaces.Add(space);
        await _context.SaveChangesAsync();

        ParkingSpaceDto result = new ParkingSpaceDto
        {
            Id = space.Id,
            Type = space.Type
        };

        return result;
    }
}