using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.SeatCommands;

public record CreateSeatsCommand(int HallId) : IRequest<List<Seat>> { }
