using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Application.Dto;

public record SeatDto(int SeatId, SeatCoordinates Coordinates) { }
