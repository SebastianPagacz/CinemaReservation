using CinemaReservation.Domain.Models;

namespace CinemaReservation.Domain.Repository.Interfaces;

public interface IHallRepository
{
    Task<CinemaHall> AddAsync(CinemaHall hall);
    Task<CinemaHall> GetByIdAsync(int id);
    Task<List<CinemaHall>> GetAsync();
    Task<CinemaHall> PatchAsync(CinemaHall hall);
    Task<bool> DeleteAsync(int id);
    Task<CinemaHall> GetHallSeatsByIdAsync(int id);
    Task<CinemaHall> GetHallShowsByIdAsync(int id);
}
