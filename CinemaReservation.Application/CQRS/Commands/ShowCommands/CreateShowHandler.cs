using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using CinemaReservation.Domain.ValueObjects;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.ShowCommands;

public class CreateShowHandler(IShowRepository showRepo, IHallRepository hallRepo) : IRequestHandler<CreateShowCommand, Result>
{
    public async Task<Result> Handle(CreateShowCommand request, CancellationToken cancellationToken)
    {
        var existingHall = await hallRepo.GetHallShowsByIdAsync(request.HallId);

        if (existingHall is null || existingHall.IsDeleted)
            return new Result(404, $"Cinema Hall with Id: {request.HallId} was not found");
        
        var isOverlap = existingHall.Shows.Where(s => s.ShowDate.Date == request.ShowDate.Date).Any(s =>
        {
            var existingStartDate = s.ShowDate;
            var existingEndDate = s.ShowDate.Add(s.Length);

            var newStartDate = request.ShowDate;
            var newEndDate = request.ShowDate.Add(request.Length);

            return existingStartDate < newEndDate && newStartDate < existingEndDate;
        });

        if (isOverlap)
            return new Result(409, "Show is overlapping.");

        //Time validation
        if (request.Length.Hours < 0)
            return new Result(422, "Hours can't be negative.");

        if (request.Length.Minutes < 0 || request.Length.Minutes >= 60)
            return new Result(422, "Invalid minutes input.");

        if (request.Length.Seconds < 0 || request.Length.Seconds >= 60)
            return new Result(422, "Invalid seconds input.");

        var newShow = new Show
        {
            Title = request.Title,
            ShowDate = request.ShowDate,
            CinemaHallId = request.HallId,
            Length = new TimeSpan(request.Length.Hours, request.Length.Minutes, request.Length.Seconds)
        };

        await showRepo.AddAsync(newShow);

        return new Result(200, new ShowDto(newShow.Title, newShow.ShowDate, newShow.Length));
    }
}
