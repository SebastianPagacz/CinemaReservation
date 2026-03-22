using CinemaReservation.Domain.Enums;

namespace CinemaReservation.Domain.Models;

public class Ticket : BaseModel
{
    public TicketEnum TicketStatus { get; set; } = TicketEnum.Processing;

    public int ShowId { get; set; }
    public Show Show { get; set; }
    public int CinemaHallId { get; set; }
    public CinemaHall CinemaHall { get; set; }
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
    public int? UserId { get; set; }
}
