using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.ShowCommands;

public record CreateShowCommand(string Title, DateTime ShowDate, TimeSpan Length, int HallId) : IRequest<Result> { }
