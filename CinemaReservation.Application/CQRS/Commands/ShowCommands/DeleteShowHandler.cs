using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.ShowCommands;

public class DeleteShowHandler(IShowRepository repository) : IRequestHandler<DeleteShowCommand, Result>
{
    public async Task<Result> Handle(DeleteShowCommand request, CancellationToken cancellationToken)
    {
        var existingShow = await repository.GetByIdAsync(request.Id);

        if (existingShow is null || existingShow.IsDeleted)
            return new Result(404, $"Show with id {request.Id} was not found.");

        await repository.DeleteAsync(request.Id);

        return new Result(200);
    }
}
