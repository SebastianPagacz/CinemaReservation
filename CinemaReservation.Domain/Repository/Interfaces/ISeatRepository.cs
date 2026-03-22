using CinemaReservation.Domain.Models;

namespace CinemaReservation.Domain.Repository.Interfaces;

public interface ISeatRepository
{
    Task<Seat> AddAsync(Seat seat);
    Task<Seat> GetByIdAsync(int id);
    Task<List<Seat>> GetAsync();
    Task<List<Seat>> GetByHallIdAsync(int hallId);
    Task<Seat> PatchAsync(Seat Seat);
    Task<bool> DeleteAsync(int id);
}
