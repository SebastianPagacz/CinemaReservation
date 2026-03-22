using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.ShowQueries;

public class GetShowByIdHandler(IShowRepository repository) : IRequestHandler<GetShowByIdQuery, Result>
{
    public async Task<Result> Handle(GetShowByIdQuery request, CancellationToken cancellationToken)
    {
        var existingShow = await repository.GetByIdAsync(request.Id);

        if (existingShow is null || existingShow.IsDeleted)
            return new Result(404, $"Show with Id {request.Id} was not found.");

        return new Result(200, new ShowDto(existingShow.Title, existingShow.ShowDate, existingShow.Length));
    }
}
