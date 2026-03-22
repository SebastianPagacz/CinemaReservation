using CinemaReservation.Application.CQRS.Commands.SeatCommands;
using CinemaReservation.Application.Dto;
using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.CinemaHallCommands;

public class CreateHallHandler(IHallRepository repository, IMediator mediator) : IRequestHandler<CreateHallCommand, Result>
{
    public async Task<Result> Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var dimensions = request.Dimensions with { Row = char.ToLower(request.Dimensions.Row) };

        var hall = new CinemaHall
        {
            Name = request.Name,
            Dimensions = dimensions,
        };

        if (hall.Dimensions.Row > 122 || hall.Dimensions.Row < 97)
            return new Result (422, "Row max number must be in range from 'a' to 'z'.");

        if (hall.Dimensions.Number <= 0 || hall.Dimensions.Number > 100)
            return new Result (422, "Maximum number of must be between '1' and '99'.");

        await repository.AddAsync(hall);

        await mediator.Send(new CreateSeatsCommand(hall.Id));

        return new Result(201, new HallDto(hall.Name, hall.Dimensions));
    }
}
