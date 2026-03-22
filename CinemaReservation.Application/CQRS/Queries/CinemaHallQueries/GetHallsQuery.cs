using CinemaReservation.Domain.Models;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.CinemaHallQueries;

public class GetHallsQuery : IRequest<Result> { }
