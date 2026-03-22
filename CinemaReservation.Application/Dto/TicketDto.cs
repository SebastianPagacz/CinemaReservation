using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Application.Dto;

public record TicketDto(string TicketStatus, string HallName, SeatCoordinates SeatCoordinates, string ShowTitle, DateTime ShowDate) { }
