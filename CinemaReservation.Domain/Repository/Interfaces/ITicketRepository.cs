using CinemaReservation.Domain.Models;

namespace CinemaReservation.Domain.Repository.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> AddAsync(Ticket ticket);
    Task<Ticket> GetByIdAsync(int id);
    Task<List<Ticket>> GetAsync();
    Task<Ticket> PatchAsync(Ticket ticket);
    Task<bool> DeleteAsync(int id);
    Task<Ticket> GetSeatShowById(int id);
}
