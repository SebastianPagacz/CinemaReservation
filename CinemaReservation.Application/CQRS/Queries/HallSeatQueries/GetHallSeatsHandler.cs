using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.HallSeatQueries;

public class GetHallSeatsHandler(IHallRepository repository) : IRequestHandler<GetHallSeatsQuery, Result>
{
    public async Task<Result> Handle(GetHallSeatsQuery request, CancellationToken cancellationToken)
    {
        var exisitngHall = await repository.GetHallSeatsByIdAsync(request.Id);

        if (exisitngHall is null || exisitngHall.IsDeleted)
            return new Result(404, $"Cinema hall with Id: {request.Id} was not found.");

        var seatsDto = exisitngHall.Seats.Where(s => !s.IsDeleted).Select(s => new SeatDto(s.Id, s.Coordinates)).ToList();

        return new Result (200, new HallSeatDto(exisitngHall.Name, seatsDto));
    }
}
