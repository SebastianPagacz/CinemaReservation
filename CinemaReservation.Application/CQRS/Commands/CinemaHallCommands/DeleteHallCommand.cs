using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.CinemaHallCommands;

public record DeleteHallCommand(int Id) : IRequest<Result> { }
