using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Queries.ShowQueries;

public class GetShowsHandler(IShowRepository repository) : IRequestHandler<GetShowsQuery, Result>
{
    public async Task<Result> Handle(GetShowsQuery request, CancellationToken cancellationToken)
    {
        var shows = await repository.GetAsync();

        return new Result(200, shows.Where(s => !s.IsDeleted).Select(s => new ShowDto(s.Title, s.ShowDate, s.Length)).ToList());
    }
}
