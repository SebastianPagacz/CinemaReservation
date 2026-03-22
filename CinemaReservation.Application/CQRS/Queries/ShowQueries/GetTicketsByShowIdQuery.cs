using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.ShowQueries;

public record GetTicketsByShowIdQuery(int ShowId) : IRequest<Result> { }
