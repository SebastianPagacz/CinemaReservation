using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.ShowCommands;

public record DeleteShowCommand(int Id) : IRequest<Result> { }
