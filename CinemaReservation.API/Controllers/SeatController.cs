using CinemaReservation.Application.CQRS.Commands.SeatCommands;
using CinemaReservation.Application.CQRS.Queries.SeatQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatController(IMediator mediator) : ControllerBase
{
    [HttpGet("{hallId}")]
    public async Task<IActionResult> GetSeatsPerHallId(int hallId)
    {
        var result = await mediator.Send(new GetSeatsForHallIdQuery(hallId));

        return StatusCode(result.StatusCode, result.Content);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteSeatCommand(id));

        return StatusCode(result.StatusCode);
    }
}
