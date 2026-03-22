namespace CinemaReservation.Application.Requests;

public record CreateTicketRequest(int ShowId, int CinemaHallId, int SeatId) { }
