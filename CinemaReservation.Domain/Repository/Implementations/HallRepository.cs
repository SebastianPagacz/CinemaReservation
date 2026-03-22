using CinemaReservation.Domain.Exceptions;
using CinemaReservation.Domain.Infrastrucutrel;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Domain.Repository.Implementations;

public class HallRepository(AppDbContext context) : IHallRepository
{
    public async Task<CinemaHall> AddAsync(CinemaHall hall)
    {
        await context.CinemaHalls.AddAsync(hall);
        await context.SaveChangesAsync();

        return hall;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingHall = await context.CinemaHalls.FirstOrDefaultAsync(h => h.Id == id);
        existingHall.IsDeleted = true;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<CinemaHall>> GetAsync()
    {
        return await context.CinemaHalls.ToListAsync();
    }

    public async Task<CinemaHall> GetByIdAsync(int id)
    {
        return await context.CinemaHalls.FirstOrDefaultAsync(h => h.Id == id);
    }

    public Task<CinemaHall> PatchAsync(CinemaHall hall)
    {
        throw new NotImplementedException();
    }

    public async Task<CinemaHall> GetHallSeatsByIdAsync(int id)
    {
        return await context.CinemaHalls.Include(c => c.Seats).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CinemaHall> GetHallShowsByIdAsync(int id)
    {
        return await context.CinemaHalls.Include(c => c.Shows).FirstOrDefaultAsync(c => c.Id == id);
    }
}
