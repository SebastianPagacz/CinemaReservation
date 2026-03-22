using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Enums;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.TicketCommands;

public class CreateTicketHandler(ITicketRepository ticketRepo, IShowRepository showRepo, IHallRepository hallRepo) : IRequestHandler<CreateTicketCommand, Result>
{
    public async Task<Result> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var exisitingShow = await showRepo.GetByIdAsync(request.ShowId);
        if (exisitingShow is null || exisitingShow.IsDeleted)
            return new Result(404, $"Show with Id: {request.ShowId} was not found.");

        var existingHall = await hallRepo.GetHallSeatsByIdAsync(request.HallId); // TODO: need to consider if this level of validation is required or if validating only by seat is sufficient
        if(existingHall is null || existingHall.IsDeleted)
            return new Result(404, $"Hall with Id: {request.HallId} was not found.");

        var existingSeat = existingHall.Seats.FirstOrDefault(s => s.Id == request.SeatId);
        if (existingSeat is null || existingSeat.IsDeleted)
            return new Result(404, $"Seat with Id: {request.SeatId} was not found.");

        var existingTickets = await ticketRepo.GetAsync();

        var isTaken = existingTickets.Where(t => t.ShowId == request.ShowId && t.SeatId == request.SeatId).Any();
        if (isTaken)
            return new Result(409, "This seat is already taken");

        var newTicket = new Ticket
        {
            TicketStatus = TicketEnum.Processing,
            ShowId = request.ShowId,
            CinemaHallId = request.HallId,
            SeatId = request.SeatId,
        };

        await ticketRepo.AddAsync(newTicket);

        return new Result(200, new TicketDto(newTicket.TicketStatus.ToString(), existingHall.Name, existingSeat.Coordinates));
    }
}
