using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.SeatCommands;

public record DeleteSeatCommand(int Id) : IRequest<Result> { }
