using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Domain.Models;

public class CinemaHall : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public HallDimensions Dimensions { get; set; }

    public List<Seat> Seats { get; set; } = new List<Seat>();
    public List<Show> Shows { get; set; } = new List<Show>();
}
