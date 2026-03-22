using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.CinemaHallQueries;

public record GetHallByIdQuery(int Id) : IRequest<Result> { }
