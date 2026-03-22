using CinemaReservation.Domain.Exceptions;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.CinemaHallCommands;

public class DeleteHallHandler(IHallRepository repository) : IRequestHandler<DeleteHallCommand, Result>
{
    public async Task<Result> Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        var existingHall = await repository.GetByIdAsync(request.Id);

        if (existingHall is null || existingHall.IsDeleted)
            return new Result(404, $"Cinema hall with Id: {request.Id} was not found.");

        await repository.DeleteAsync(request.Id);
        return new Result(204);
    }
}
