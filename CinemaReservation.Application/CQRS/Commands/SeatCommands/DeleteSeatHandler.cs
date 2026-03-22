using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.SeatCommands;

public class DeleteSeatHandler(ISeatRepository repository) : IRequestHandler<DeleteSeatCommand, Result>
{
    public async Task<Result> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        var existingSeat = await repository.GetByIdAsync(request.Id);

        if (existingSeat is null || existingSeat.IsDeleted)
            return new Result (404, $"Seat with Id: {request.Id} was not found.");

        await repository.DeleteAsync(existingSeat.Id);

        return new Result(204);
    }
}
