using System.Text.Json.Serialization;

namespace CinemaReservation.Domain.Models;

public class BaseModel
{
    [JsonPropertyOrder(1)]
    public int Id { get; set; }
    [JsonPropertyOrder(2)]
    public bool IsDeleted { get; set; } = false;
    [JsonPropertyOrder(3)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonPropertyOrder(4)]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
