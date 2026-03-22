using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.HallSeatQueries;

public record GetHallSeatsQuery(int Id) : IRequest<Result> { }
