using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingReservation.Application.DTOs;

namespace ParkingReservation.Application.Services;

public interface IReservationService
{
    Task<List<ReservationDto>> GetAllAsync();
    Task<List<ReservationDto>> GetByParkingSpaceIdAsync(int parkingSpaceId);
    Task<ReservationDto?> CreateAsync(CreateReservationDto dto);
    Task<bool> DeleteAsync(int id);
}