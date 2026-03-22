using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.SeatQueries;

public record GetSeatsForHallIdQuery(int HallId) : IRequest<Result> { }
