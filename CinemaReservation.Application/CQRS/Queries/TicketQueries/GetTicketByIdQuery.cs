using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.TicketQueries;

public record GetTicketByIdQuery(int TicketId) : IRequest<Result> { }
