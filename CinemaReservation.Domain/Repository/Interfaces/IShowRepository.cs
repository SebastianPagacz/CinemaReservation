using CinemaReservation.Domain.Models;

namespace CinemaReservation.Domain.Repository.Interfaces;

public interface IShowRepository
{
    Task<Show> AddAsync(Show show);
    Task<Show> GetByIdAsync(int id);
    Task<List<Show>> GetAsync();
    Task<Show> PatchAsync(Show show);
    Task<bool> DeleteAsync(int id);
}
