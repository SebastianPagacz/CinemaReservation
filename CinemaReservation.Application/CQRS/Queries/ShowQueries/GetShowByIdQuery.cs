using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.ShowQueries;

public record GetShowByIdQuery(int Id) : IRequest<Result> { }
