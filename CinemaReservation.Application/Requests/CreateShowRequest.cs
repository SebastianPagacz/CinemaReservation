using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Application.Requests;

public record CreateShowRequest(string Title, DateTime ShowDate, TimeSpan ShowLength, int HallId) { }

