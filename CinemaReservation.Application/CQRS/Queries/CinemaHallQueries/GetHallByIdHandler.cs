using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.CinemaHallQueries;

public class GetHallByIdHandler(IHallRepository repository) : IRequestHandler<GetHallByIdQuery, Result>
{
    public async Task<Result> Handle(GetHallByIdQuery request, CancellationToken cancellationToken)
    {
        var hall = await repository.GetByIdAsync(request.Id);

        if (hall is null || hall.IsDeleted)
            return new Result(404, $"Cinema hall with Id: {request.Id} was not found.");

        return new Result(200, new HallDto(hall.Name, hall.Dimensions));
    }
}
