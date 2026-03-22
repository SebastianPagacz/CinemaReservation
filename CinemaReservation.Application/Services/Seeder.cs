using CinemaReservation.Application.CQRS.Commands.CinemaHallCommands;
using CinemaReservation.Application.CQRS.Commands.ShowCommands;
using CinemaReservation.Domain.Infrastrucutre.DataSeeder;
using CinemaReservation.Domain.Infrastrucutrel;
using CinemaReservation.Domain.ValueObjects;
using MediatR;

namespace CinemaReservation.Application.Services;

public class Seeder(IMediator mediator, AppDbContext context) : ISeeder
{
    public async Task SeedAsync()
    {
        if (!context.CinemaHalls.Any())
        {
            await mediator.Send(new CreateHallCommand("Duza sala", new HallDimensions('l', 12)));
            await mediator.Send(new CreateHallCommand("Srednia sala", new HallDimensions('g', 8)));
            await mediator.Send(new CreateHallCommand("Mala sala", new HallDimensions('d', 5)));
        }

        if (!context.Shows.Any())
        {
            await mediator.Send(new CreateShowCommand("Niezly film", new DateTime(2026, 3, 19, 12, 0, 0), new TimeSpan(1, 40, 12), 1));
            await mediator.Send(new CreateShowCommand("Film Oscarowy", new DateTime(2026, 3, 19, 12, 0, 0), new TimeSpan(2, 30, 00), 2));
            await mediator.Send(new CreateShowCommand("Sredni film", new DateTime(2026, 3, 19, 12, 0, 0), new TimeSpan(2, 12, 53), 3));
            await mediator.Send(new CreateShowCommand("Film z gwiazdami", new DateTime(2026, 3, 19, 14, 0, 0), new TimeSpan(2, 00, 00), 1));
            await mediator.Send(new CreateShowCommand("Film artystyczny", new DateTime(2026, 3, 20, 17, 0, 0), new TimeSpan(1, 32, 12), 1));
        }
    }
}
