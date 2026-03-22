using CinemaReservation.Domain.Models;
using CinemaReservation.Domain.Repository.Interfaces;
using CinemaReservation.Domain.ValueObjects;
using MediatR;

namespace CinemaReservation.Application.CQRS.Commands.SeatCommands;

public class CreateSeatsHandler(IHallRepository hallRepo, ISeatRepository seatRepo) : IRequestHandler<CreateSeatsCommand, List<Seat>>
{
    public async Task<List<Seat>> Handle(CreateSeatsCommand request, CancellationToken cancellationToken)
    {
        var existingHall = await hallRepo.GetByIdAsync(request.HallId);

        var hallRows = existingHall.Dimensions.Row - 96; // ASCII calculations
        var hallNumber = existingHall.Dimensions.Number;

        for (int i = 1; i <= hallRows; i++)
        {
            for(int j = 1; j <= hallNumber; j++)
            {
                var seat = new Seat
                {
                    Coordinates = new SeatCoordinates((char)(i + 96), j),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CinemaHallId = request.HallId,
                };
                await seatRepo.AddAsync(seat);
            }
        }

        return await seatRepo.GetAsync();
    }
}
