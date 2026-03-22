using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Domain.Models;

public class Seat : BaseModel
{
    public int CinemaHallId { get; set; }
    public SeatCoordinates Coordinates { get; set; }
}
