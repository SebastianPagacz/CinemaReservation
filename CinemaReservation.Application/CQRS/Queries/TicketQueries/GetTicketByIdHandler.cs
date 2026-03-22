using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.TicketQueries;

public class GetTicketByIdHandler(ITicketRepository repository) : IRequestHandler<GetTicketByIdQuery, Result>
{
    public async Task<Result> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var existingTicket = await repository.GetSeatShowById(request.TicketId);

        if (existingTicket is null || existingTicket.IsDeleted)
            return new Result(404, $"Ticket with Id: {request.TicketId} was not found.");

        return new Result(200, new TicketDto(existingTicket.TicketStatus.ToString(), existingTicket.CinemaHall.Name, existingTicket.Seat.Coordinates));
    }
}
