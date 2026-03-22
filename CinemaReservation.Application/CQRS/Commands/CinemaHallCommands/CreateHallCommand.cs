using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.ValueObjects;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.CinemaHallCommands;

public record CreateHallCommand(string Name, HallDimensions Dimensions) : IRequest<Result> { }
