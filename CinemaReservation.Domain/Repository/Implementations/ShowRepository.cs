using CinemaReservation.Domain.Exceptions;
using CinemaReservation.Domain.Infrastrucutrel;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Domain.Repository.Implementations;

public class ShowRepository(AppDbContext context) : IShowRepository
{
    public async Task<Show> AddAsync(Show show)
    {
        await context.Shows.AddAsync(show);
        await context.SaveChangesAsync();

        return show;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var exisitingShow = await context.Shows.FirstOrDefaultAsync(s => s.Id == id);
        exisitingShow.IsDeleted = true;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Show>> GetAsync()
    {
        return await context.Shows.ToListAsync();
    }

    public async Task<Show> GetByIdAsync(int id)
    {
        return await context.Shows.FirstOrDefaultAsync(s => s.Id == id);
    }

    public Task<Show> PatchAsync(Show show)
    {
        throw new NotImplementedException();
    }
}
