using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingReservation.Application.DTOs;

namespace ParkingReservation.Application.Services;

public interface IParkingSpaceService
{
    Task<List<ParkingSpaceDto>> GetAllAsync();
    Task<ParkingSpaceDto> CreateAsync(CreateParkingSpaceDto dto);
}