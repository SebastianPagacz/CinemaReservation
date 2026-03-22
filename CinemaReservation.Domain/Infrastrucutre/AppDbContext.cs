using CinemaReservation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Domain.Infrastrucutrel;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
