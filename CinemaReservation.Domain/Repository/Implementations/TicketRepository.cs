using CinemaReservation.Domain.Exceptions;
using CinemaReservation.Domain.Infrastrucutrel;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Domain.Repository.Implementations;

public class TicketRepository(AppDbContext context) : ITicketRepository
{
    public async Task<Ticket> AddAsync(Ticket ticket)
    {
        await context.Tickets.AddAsync(ticket);
        await context.SaveChangesAsync();

        return ticket;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var exisitingTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        exisitingTicket.IsDeleted = true;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Ticket>> GetAsync()
    {
        return await context.Tickets.ToListAsync();
    }

    public async Task<Ticket> GetByIdAsync(int id)
    {
        return await context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task<Ticket> PatchAsync(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public async Task<Ticket> GetSeatShowById(int id)
    {
        return await context.Tickets.Include(t => t.Seat).Include(t => t.CinemaHall).FirstOrDefaultAsync(t => t.Id == id);
    }
}
