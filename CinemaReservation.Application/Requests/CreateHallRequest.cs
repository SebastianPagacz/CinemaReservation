using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Application.Requests;

public record CreateHallRequest
{
    public string Name { get; set; } = string.Empty;
    public HallDimensions Dimensions { get; set; }
}
