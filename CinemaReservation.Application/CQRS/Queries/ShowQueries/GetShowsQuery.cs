using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.ShowQueries;

public record GetShowsQuery() : IRequest<Result> { }
