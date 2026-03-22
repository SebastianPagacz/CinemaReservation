namespace CinemaReservation.Application.Dto;

public record HallSeatDto(string HallName, List<SeatDto> Seats) { }
