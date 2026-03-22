using CinemaReservation.Application.CQRS.Commands.TicketCommands;
using CinemaReservation.Application.CQRS.Queries.ShowQueries;
using CinemaReservation.Application.CQRS.Queries.TicketQueries;
using CinemaReservation.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(CreateTicketRequest request)
    {
        var result = await mediator.Send(new CreateTicketCommand(request.ShowId, request.CinemaHallId, request.SeatId));

        return StatusCode(result.StatusCode, result.Content);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetTicketByIdQuery(id));

        return StatusCode(result.StatusCode, result.Content);
    }

    [HttpGet("ticket/{showId}")]
    public async Task<IActionResult> GetByTicketId(int showId)
    {
        var result = await mediator.Send(new GetTicketsByShowIdQuery(showId));

        return StatusCode(result.StatusCode, result.Content);
    }
}
