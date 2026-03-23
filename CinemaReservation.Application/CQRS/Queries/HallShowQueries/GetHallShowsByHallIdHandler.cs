using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.HallShowQueries;

public class GetHallShowsByHallIdHandler(IHallRepository hallRepo) : IRequestHandler<GetHallShowsByHallIdQuery, Result>
{
    public async Task<Result> Handle(GetHallShowsByHallIdQuery request, CancellationToken cancellationToken)
    {
        var existingHall = await hallRepo.GetHallShowsByIdAsync(request.HallId);
        if (existingHall is null || existingHall.IsDeleted)
            return new Result(404, $"Cinema hall with Id: {request.HallId} was not found.");

        return new Result(200, existingHall.Shows.Where(s => !s.IsDeleted).Select(s => new ShowDto(s.Title, s.ShowDate, s.Length)));
    }
}