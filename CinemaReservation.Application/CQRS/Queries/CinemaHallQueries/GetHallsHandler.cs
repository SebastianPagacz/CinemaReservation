using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.CinemaHallQueries;

public class GetHallsHandler(IHallRepository repository) : IRequestHandler<GetHallsQuery, Result>
{
    public async Task<Result> Handle(GetHallsQuery request, CancellationToken cancellationToken)
    {
        var halls = await repository.GetAsync();

        return new Result(200, halls.Where(h => !h.IsDeleted).Select(h => new HallDto(h.Name, h.Dimensions)).ToList());
    }
}
