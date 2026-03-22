namespace CinemaReservation.Domain.Models;

public class Show : BaseModel
{
    public string Title { get; set; } = string.Empty;
    public DateTime ShowDate { get; set; }
    public TimeSpan Length { get; set; }

    public int CinemaHallId { get; set; }
}
