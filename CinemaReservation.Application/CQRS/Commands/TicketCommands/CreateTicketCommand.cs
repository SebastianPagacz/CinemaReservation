using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.TicketCommands;

public record CreateTicketCommand(int ShowId, int HallId, int SeatId) : IRequest<Result> { }
