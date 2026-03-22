using CinemaReservation.Domain.Exceptions;
using CinemaReservation.Domain.Infrastrucutrel;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Domain.Repository.Implementations;

public class SeatRepository(AppDbContext context) : ISeatRepository
{
    public async Task<Seat> AddAsync(Seat seat)
    {
        await context.Seats.AddAsync(seat);
        await context.SaveChangesAsync();

        return seat;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingSeat = await context.Seats.FirstOrDefaultAsync(s => s.Id == id);
        existingSeat.IsDeleted = true;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Seat>> GetAsync()
    {
        return await context.Seats.ToListAsync();
    }

    public async Task<List<Seat>> GetByHallIdAsync(int hallId)
    {
        return await context.Seats.Where(s => s.CinemaHallId == hallId).ToListAsync();
    }
    public async Task<Seat> GetByIdAsync(int id)
    {
        return await context.Seats.FirstOrDefaultAsync(s => s.Id == id);
    }

    public Task<Seat> PatchAsync(Seat Seat)
    {
        throw new NotImplementedException();
    }
}
