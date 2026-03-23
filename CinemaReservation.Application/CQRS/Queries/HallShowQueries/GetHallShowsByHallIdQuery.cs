using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.HallShowQueries;

public record GetHallShowsByHallIdQuery(int HallId) : IRequest<Result> { }