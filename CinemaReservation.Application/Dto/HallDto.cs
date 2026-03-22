using CinemaReservation.Domain.ValueObjects;

namespace CinemaReservation.Application.Dto;

public record HallDto(string Name, HallDimensions Dimensions) { }
