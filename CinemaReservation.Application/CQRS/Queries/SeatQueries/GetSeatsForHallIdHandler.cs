using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.SeatQueries;

public class GetSeatsForHallIdHandler(IHallRepository hallRepo, ISeatRepository seatRepo) : IRequestHandler<GetSeatsForHallIdQuery, Result>
{
    public async Task<Result> Handle(GetSeatsForHallIdQuery request, CancellationToken cancellationToken)
    {
        var exisitingHall = await hallRepo.GetByIdAsync(request.HallId);

        if (exisitingHall is null || exisitingHall.IsDeleted)
            return new Result(404, $"Cinema hall with Id: {request.HallId} was not found.");

        var seats = await seatRepo.GetByHallIdAsync(exisitingHall.Id);

        return new Result(200, seats.Where(s => !s.IsDeleted).Select(s => new SeatDto(s.Id, s.Coordinates)).ToList());
    }
}
