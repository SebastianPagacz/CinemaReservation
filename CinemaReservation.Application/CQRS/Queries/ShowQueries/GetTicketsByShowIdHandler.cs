using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.ShowQueries;

public class GetTicketsByShowIdHandler(ITicketRepository repository) : IRequestHandler<GetTicketsByShowIdQuery, Result>
{
    public async Task<Result> Handle(GetTicketsByShowIdQuery request, CancellationToken cancellationToken)
    {
        var tickets = await repository.GetTicketsByShowIdAsync(request.ShowId);

        return new Result(200, tickets.Select(t => new TicketDto(t.TicketStatus.ToString(), t.CinemaHall.Name, t.Seat.Coordinates, t.Show.Title, t.Show.ShowDate)));
    }
}
